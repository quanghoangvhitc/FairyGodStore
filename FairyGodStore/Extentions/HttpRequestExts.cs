using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System;

namespace FairyGodStore
{
    public static class HttpRequestExts
    {
        public static bool IsAdmin(this HttpRequest req)
        {
            try
            {
                string JwtToken = req.Cookies["Authorization"];
                if (!JwtToken.IsEmpty())
                {
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadToken(JwtToken) as JwtSecurityToken;

                    if (jwtSecurityToken != null && jwtSecurityToken.ValidTo > DateTime.UtcNow)
                    {
                        string roles = jwtSecurityToken.Claims.SingleOrDefault(c => c.Type.Equals("roles"))?.Value;
                        if (!roles.IsEmpty() && roles.Split(',').Any(r => r.ToLower().Equals("admin")))
                            return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }

        public static bool IsManager(this HttpRequest req)
        {
            try
            {
                string JwtToken = req.Cookies["Authorization"];
                if (!JwtToken.IsEmpty())
                {
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadToken(JwtToken) as JwtSecurityToken;

                    if (jwtSecurityToken != null && jwtSecurityToken.ValidTo > DateTime.UtcNow)
                    {
                        string roles = jwtSecurityToken.Claims.SingleOrDefault(c => c.Type.Equals("roles"))?.Value;
                        if (roles.Split(',').Any(r => new[] { "admin", "manager" }.Any(m => m.Equals(r.ToLower()))))
                            return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
