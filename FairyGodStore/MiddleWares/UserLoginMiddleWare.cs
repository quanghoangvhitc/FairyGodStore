using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.MiddleWares
{
    public class UserLoginMiddleWare
    {
        private readonly RequestDelegate _next;
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

        public UserLoginMiddleWare(RequestDelegate _next)
        {
            this._next = _next;
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

        public async Task Invoke(HttpContext context)
        {
            string JwtToken = context.Request.Cookies["Authorization"];

            JwtSecurityToken jwtSecurityToken = GetJwtSecurityToken(JwtToken);
            if (jwtSecurityToken != null && jwtSecurityToken.ValidTo > DateTime.UtcNow)
            {
                if (context.Request.Path.Value.ToLower().StartsWith("/authen"))
                    context.Response.Redirect("/");
            }
            else
            {
                if (context.Request.Path.Value.ToLower().StartsWith("/api"))
                {
                    if (!context.Request.Path.Value.ToLower().StartsWith("/api/authen"))
                    {
                        context.Response.Redirect("/api/authen");
                        return;
                    }
                }
                else
                {
                    if (context.Request.Path.Value != "/"
                        && !context.Request.Path.Value.ToLower().StartsWith("/authen"))
                        context.Response.Redirect("/authen");
                }
            }

            await _next(context);
        }
    }
}
