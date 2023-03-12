using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("api/book")]
    public class ApiBook : ApiBase
    {
        public ApiBook(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.book.OrderByDescending(b => b.Modified).ToListAsync();
                return new ApiResults<Book>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.book
                                        .Include(b => b.BookComments)
                                        .Include(b => b.BookContents)
                                        .Include(b => b.Favorites)
                                        .Include(b => b.Ratings)
                                        .SingleOrDefaultAsync(b => b.Id.Equals(id));
                return new ApiResult<Book>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            return Ok(await ApiResponse(async () =>
            {
                await context.book.AddAsync(book);
                await context.SaveChangesAsync();
                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] Book book)
        {
            return Ok(await ApiResponse(async () =>
            {
                if (id != book.Id)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_VALID());

                var db = await context.book.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (db == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                db.Title = book.Title;
                db.Author = book.Author;
                db.ReleaseDate = book.ReleaseDate;
                db.Thumbnail = book.Thumbnail;
                db.SortDescription = book.SortDescription;
                db.ModifiedBy = book.ModifiedBy;
                db.Modified = book.Modified;

                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var b = await context.book.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (b == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                context.Remove(b);
                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }
    }
}
