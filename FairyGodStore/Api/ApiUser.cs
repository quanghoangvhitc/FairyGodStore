using FairyGodStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("api/user")]
    public class ApiUser : ApiBase
    {
        public ApiUser(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var ret = await context?.user?.Include(x=>x.Roles).ToListAsync();
            //return new ApiResult<User>() 
            //{ 
            //    Status = true, 
            //    ErrMess = new KeyValuePair<string, string>("",""), 
            //    Data = new User() { FullName = "HoàngPQ" }, 
            //    TimeNow = DateTime.Now.Ticks
            //};

            return Ok(JsonConvert.SerializeObject(new ApiResults<User>()
            {
                Status = true,
                ErrMess = new KeyValuePair<string, string>("", ""),
                Data = ret,
                TimeNow = DateTime.Now.Ticks
            }));
        }
    }
}
