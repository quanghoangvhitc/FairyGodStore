using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System;

namespace FairyGodStore.MiddleWares
{
    public class SwaggerMiddleware
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

        public SwaggerMiddleware(RequestDelegate _next)
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
            if (context.Request.Path.Value.ToLower().StartsWith("/api/docs"))
            {
                string JwtToken = context.Request.Cookies["Authorization"];
                JwtSecurityToken jwtSecurityToken = GetJwtSecurityToken(JwtToken);
                if (jwtSecurityToken == null ||
                   (jwtSecurityToken != null && jwtSecurityToken.ValidTo < DateTime.UtcNow))
                {
                    context.Response.Redirect("/api/authen");
                    return;
                }
            }

            await _next(context);
        }
    }
}
