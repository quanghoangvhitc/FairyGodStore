using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FairyGodStore.Api.ApiBase;

namespace FairyGodStore.Api
{
    [Route("api/user")]
    public class ApiUser : ApiBase
    {
        public ApiUser(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.user.ToListAsync();
                return new ApiResults<User>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.user
                                        .Include(u => u.Roles)
                                        .Include(u=>u.Favorites)
                                        .Include(u => u.Reports)
                                        .SingleOrDefaultAsync(u => u.Id.Equals(id));
                return new ApiResult<User>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }
    }
}
