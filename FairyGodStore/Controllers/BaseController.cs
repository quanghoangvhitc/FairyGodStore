using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace FairyGodStore.Controllers
{
    public class BaseController : Controller
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

        public BaseController(DatabaseContext context, IConfiguration configuration)
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

        public long GetUserId()
        {
            JwtSecurityToken jwtSecurityToken = GetJwtSecurityToken(Request.Cookies["Authorization"]);
            Claim claim = jwtSecurityToken.Claims.SingleOrDefault(c => c.Type.Equals("ID"));
            long userId;
            if (long.TryParse(claim.Value, out userId))
            {
                return userId;
            }
            return -1;
        }
    }
}
