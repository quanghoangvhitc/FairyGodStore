﻿using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
                {
                    string roles = jwtSecurityToken.Claims.SingleOrDefault(c => c.Type.Equals("roles"))?.Value;
                    if (roles.Split(',').Any(r => new[] { "admin", "manager" }.Any(m => m.Equals(r.ToLower()))))
                    {
                        //string url = context.Request.Path.Value.ToLower();
                        //if (!url.Contains("/admin"))
                        //{
                        //    context.Response.Redirect($"/admin{(url.Equals("/") ? "" : url)}");
                        //    return;
                        //}
                        context.Response.Redirect("/admin");
                    }
                    else
                    {
                        context.Response.Redirect("/");
                    }    
                }  
            }
            //if (jwtSecurityToken != null && jwtSecurityToken.ValidTo > DateTime.UtcNow)
            //{
            //    if (context.Request.Path.Value.ToLower().StartsWith("/authen"))
            //        context.Response.Redirect("/");
            //}
            //else
            //{
            //    if (context.Request.Path.Value.ToLower().StartsWith("/api"))
            //    {
            //        if (!context.Request.Path.Value.ToLower().StartsWith("/api/authen"))
            //        {
            //            context.Response.Redirect("/api/authen");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        if (context.Request.Path.Value != "/"
            //            && !context.Request.Path.Value.ToLower().StartsWith("/authen"))
            //            context.Response.Redirect("/authen");
            //    }
            //}

            await _next(context);
        }
    }
}
