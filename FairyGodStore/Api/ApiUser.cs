using FairyGodStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("api/user")]
    public class ApiUser : ApiBase
    {
        [HttpGet]
        public ApiResult<User> Get()
        {
            return new ApiResult<User>() 
            { 
                Status = true, 
                ErrMess = new KeyValuePair<string, string>("",""), 
                Data = new User() { FullName = "HoàngPQ" }, 
                TimeNow = DateTime.Now.Ticks
            };
        }
    }
}
