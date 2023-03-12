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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            return Ok(await ApiResponse(async () =>
            {
                await context.user.AddAsync(user);
                await context.SaveChangesAsync();
                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] User user)
        {
            return Ok(await ApiResponse(async () =>
            {
                if (id != user.Id)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_VALID());

                var db = await context.user.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (db == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                db.FullName = user.FullName;
                db.Email = user.Email;
                db.Address = user.Address;
                db.IdentityCard = user.IdentityCard;
                db.Avatar = user.Avatar;
                db.PhoneNumber = user.PhoneNumber;
                db.Status = user.Status;
                db.Gender = user.Gender;
                db.ModifiedBy = user.ModifiedBy;
                db.Modified = user.Modified;

                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var b = await context.user.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (b == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                context.Remove(b);
                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }
    }
}
