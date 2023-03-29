using FairyGodStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace FairyGodStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class AdminBase : Controller
    {
        private DatabaseContext _context;
        private IConfiguration _configuration;
        internal DatabaseContext context { get => _context; }
        internal IConfiguration configuration { get => _configuration; }

        private static JwtSecurityTokenHandler _JwtHandler = null;
        private static JwtSecurityTokenHandler JwtHandler
        {
            get
            {
                if (_JwtHandler == null)
                    _JwtHandler = new JwtSecurityTokenHandler();
                return _JwtHandler;
            }
        }

        public AdminBase(DatabaseContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        private JwtSecurityToken GetJwtSecurityToken(string JwtToken)
        {
            if (JwtToken.IsEmpty())
                return null;

            try
            {
                return JwtHandler.ReadToken(JwtToken) as JwtSecurityToken;
            }
            catch
            {
                return null;
            }
        }

        internal long GetUserId()
        {
            JwtSecurityToken jwtSecurityToken = GetJwtSecurityToken(Request.Cookies["Authorization"]);
            Claim claim = jwtSecurityToken.Claims.SingleOrDefault(c => c.Type.Equals("id"));
            long userId;
            if (long.TryParse(claim.Value, out userId))
            {
                return userId;
            }
            return -1;
        }
    }
}
