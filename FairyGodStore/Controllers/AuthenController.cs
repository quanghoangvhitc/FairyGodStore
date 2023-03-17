using FairyGodStore.Helpers;
using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FairyGodStore.Controllers
{
    public class AuthenController : BaseController
    {
        private readonly byte[] _KeyBytes;
        public AuthenController(DatabaseContext context, IConfiguration configuration) : base(context, configuration)
        {
            var secretKey = configuration["AppSettings:SecretKey"];
            _KeyBytes = Encoding.UTF8.GetBytes(secretKey);
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Authentication";
            return View("Views/Authen/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Authenticate(LoginViewModel loginViewModel)
        {
            ViewBag.Username = loginViewModel.Username;

            User user = null;

            if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
            {
                string psw = Crypter.GetMD5($"{loginViewModel.Username}-{loginViewModel.Password}");

                user = context.user
                            .Include(u => u.Roles)
                            .SingleOrDefault(u => u.Email == loginViewModel.Username && u.Password == psw);
            }

            if (user == null)
            {
                ViewBag.Err = "Sai thông tin đăng nhập!";
            }
            else
            {
                IList<string>? userRoles = null;
                if (user.Roles != null)
                    userRoles = user.Roles.Select(x => x.Title).ToList();

                string token = TokenHelper.GenerateToken(configuration["JWT:Secret"], configuration["JWT:ValidIssuer"], configuration["JWT:ValidAudience"]
                            , userRoles, user.Id.ToString(), user.Email, user.FullName);

                HttpContext.Response.Cookies.Append("Authorization", token);

                //thông tin đặc trưng của user
                //var claims = new List<Claim>()
                //{
                //    new Claim(ClaimTypes.Name, user.FullName),
                //    new Claim(ClaimTypes.Email, user.Email),
                //    new Claim("ID", user.Id.ToString())
                //};

                //var tokenHandler = new JwtSecurityTokenHandler();
                //var tokenDesc = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(claims),
                //    Expires = DateTime.UtcNow.AddYears(10),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_KeyBytes), SecurityAlgorithms.HmacSha512)
                //};
                //var token = tokenHandler.CreateToken(tokenDesc);
                //var dataToken = tokenHandler.WriteToken(token);

                //if (dataToken != null)
                //{
                //    //Save token in cookie object
                //    CookieOptions opt = new CookieOptions();
                //    //opt.Expires = DateTime.UtcNow.AddMonths(1);
                //    opt.Expires = DateTime.UtcNow.AddYears(10);
                //    HttpContext.Response.Cookies.Append("Authorization", dataToken, opt);
                //    //Save token in session object
                //    //HttpContext.Session.SetString("JWToken", dataToken);
                //    //Cách xóa cookie
                //    //HttpContext.Response.Cookies.Delete("JWToken");
                //}

                ViewBag.Fullname = user.FullName;
                ViewBag.Email = user.Email;
                ViewBag.Roles = user.Roles;

                if (user.Roles.Any(r=> new[] { "admin", "manager" }.Any(m=>m.Equals(r.Title.ToLower()))))
                    return Redirect("/admin");

                return Redirect("/");
            }
            return View("Views/Authen/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                var jwtoken = HttpContext.Request.Cookies["Authorization"];
                if (jwtoken != null)
                    HttpContext.Response.Cookies.Delete("Authorization");
                return Ok(new
                {
                    Status = true,
                    ErrMess = MessageViewModel.LOGOUT_SUCCESS,
                    Data = "",
                    TimeNow = DateTime.Now.Ticks
                });
            }
            catch
            {
                return Ok(new
                {
                    Status = false,
                    ErrMess = MessageViewModel.LOGOUT_FAIL,
                    Data = "",
                    TimeNow = DateTime.Now.Ticks
                });
            }
        }
    }
}
