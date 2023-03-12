using FairyGodStore.Helpers;
using FairyGodStore.Models;
using FairyGodStore.ViewModels;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FairyGodStore.Api
{
    [Route("api/authen")]
    public class ApiAuthen : ApiBase
    {
        private readonly byte[] _KeyBytes;
        public ApiAuthen(DatabaseContext context, IConfiguration configuration) : base(context, configuration)
        {
            var secretKey = configuration["AppSettings:SecretKey"];
            _KeyBytes = Encoding.UTF8.GetBytes(secretKey);
        }

        [HttpGet("/api/authen")]
        public IActionResult Index()
        {
            return Ok(new ApiResult<object>(data: null, status: false, MessageViewModel.AUTHEN));
        }

        private LoginTokenViewModel CheckLogin(LoginViewModel loginViewModel, bool IsGuest = false)
        {
            User user = null;

            string psw = loginViewModel.Password;

            if (!IsGuest)
                psw = Crypter.GetMD5(loginViewModel.Password);

            user = context.user
                        .Include(u => u.Roles)
                        .SingleOrDefault(u => u.Email == loginViewModel.Username && u.Password == psw);

            if (user == null)
                return null;
            else
            {
                //thông tin đặc trưng của user
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("ID", user.Id.ToString())
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddYears(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_KeyBytes), SecurityAlgorithms.HmacSha512)
                };
                var token = tokenHandler.CreateToken(tokenDesc);

                return new LoginTokenViewModel(user, tokenHandler.WriteToken(token));
            }
        }

        [HttpGet("/api/authen/guest")]
        public IActionResult Guest()
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = configuration["UserGuest:Email"],
                Password = configuration["UserGuest:Password"]
            };

            LoginTokenViewModel data = CheckLogin(loginViewModel, true);

            return Ok(new ApiResult<LoginTokenViewModel>(data: data, status: true, data == null ? MessageViewModel.LOGIN_FAIL : MessageViewModel.LOGIN_SUCCESS));
        }

        [HttpPost("/api/authen/login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            LoginTokenViewModel data = CheckLogin(loginViewModel);

            return Ok(new ApiResult<LoginTokenViewModel>(data: data, status: true, data == null ? MessageViewModel.LOGIN_FAIL : MessageViewModel.LOGIN_SUCCESS));
        }
    }
}
