using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("/api/role")]
    public class ApiRole : ApiBase
    {
        public ApiRole(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<ActionResult> Index(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.role.Include(r => r.Users).ToListAsync();
                return new ApiResults<Role>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.role.SingleOrDefaultAsync(b => b.Id.Equals(id));
                return new ApiResult<Role>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Role role)
        {
            return Ok(await ApiResponse(async () =>
            {
                await context.role.AddAsync(role);
                await context.SaveChangesAsync();
                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] Role role)
        {
            return Ok(await ApiResponse(async () =>
            {
                if (id != role.Id)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_VALID());

                var db = await context.role.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (db == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                db.Title = role.Title;
                db.Users = role.Users;
                db.Description = role.Description;
                db.ModifiedBy = role.ModifiedBy;
                db.Modified = role.Modified;

                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var b = await context.role.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (b == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                context.Remove(b);
                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }
    }
}
