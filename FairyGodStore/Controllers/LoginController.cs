using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FairyGodStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            return View("Views/Login/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Authenticate(string uname, string psw)
        {
            /*
            UserInfo info = new UserInfo();
            VUserInfo vinfo = info.Login(userName, password);
            if (vinfo != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, vinfo.Username),
                    new Claim(ClaimTypes.Email, vinfo.Email),
                    new Claim("UserLogin", vinfo.Username),
                    new Claim("UserName", vinfo.FullName)
                };
                if (vinfo.IsAdmin)
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                if (vinfo.IsManager)
                    claims.Add(new Claim(ClaimTypes.Role, "manager"));
                claims.Add(new Claim(ClaimTypes.Role, "home"));

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SettingInfo.SecretKeyByte), SecurityAlgorithms.HmacSha512)
                };
                var token = tokenHandler.CreateToken(tokenDesc);
                var dataToken = tokenHandler.WriteToken(token);
                if (dataToken != null)
                {
                    //Save token in cookie object
                    CookieOptions opt = new CookieOptions();
                    //opt.Expires = DateTime.UtcNow.AddMonths(1);
                    opt.Expires = DateTime.UtcNow.AddDays(1);
                    HttpContext.Response.Cookies.Append("JWToken", dataToken, opt);
                    //Save token in session object
                    //HttpContext.Session.SetString("JWToken", dataToken);
                    //Cách xóa cookie
                    //HttpContext.Response.Cookies.Delete("JWToken");
                }
                if (vinfo.IsAdmin)
                {
                    return Redirect("/Admin/Home");
                }
                return Redirect("/");
            }
            ViewBag.uName = userName;
            ViewBag.Err = new ActionValue() { Status = false, Message = "Sai thông tin đăng nhập!" };
            */
            return View("Views/Login/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            //ActionValue act;
            //try
            //{
            //    var jwtoken = HttpContext.Request.Cookies["JWToken"];
            //    if (jwtoken != null)
            //        HttpContext.Response.Cookies.Delete("JWToken");
            //    act = new ActionValue() { Status = true };
            //}
            //catch (Exception ex)
            //{
            //    act = new ActionValue() { Status = false, Message = ex.Message };
            //}
            return Ok("");
        }
    }
}
