using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("/api/bookcategory")]
    public class ApiBookCategory : ApiBase
    {
        public ApiBookCategory(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<ActionResult> Index(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.bookCategory.Include(r => r.books).ToListAsync();
                return new ApiResults<BookCategory>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.bookCategory.SingleOrDefaultAsync(b => b.Id.Equals(id));
                return new ApiResult<BookCategory>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookCategory bookCategory)
        {
            return Ok(await ApiResponse(async () =>
            {
                await context.bookCategory.AddAsync(bookCategory);
                await context.SaveChangesAsync();
                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] BookCategory bookCategory)
        {
            return Ok(await ApiResponse(async () =>
            {
                if (id != bookCategory.Id)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_VALID());

                var db = await context.bookCategory.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (db == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                db.Title = bookCategory.Title;
                db.books = bookCategory.books;
                db.ModifiedBy = bookCategory.ModifiedBy;
                db.Modified = bookCategory.Modified;

                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var b = await context.bookCategory.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (b == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                context.Remove(b);
                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }
    }
}
