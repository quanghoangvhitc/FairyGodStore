using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("/api/bookcomment")]
    public class ApiBookComment : ApiBase
    {
        public ApiBookComment(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.bookComment.SingleOrDefaultAsync(b => b.Id.Equals(id));
                return new ApiResult<BookComment>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookComment bookComment)
        {
            return Ok(await ApiResponse(async () =>
            {
                await context.bookComment.AddAsync(bookComment);
                await context.SaveChangesAsync();
                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] BookComment bookComment)
        {
            return Ok(await ApiResponse(async () =>
            {
                if (id != bookComment.Id)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_VALID());

                var db = await context.bookComment.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (db == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                db.DisLikeCount = bookComment.DisLikeCount;
                db.Content = bookComment.Content;
                db.LikeCount = bookComment.LikeCount;
                db.ModifiedBy = bookComment.ModifiedBy;
                db.Modified = bookComment.Modified;

                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var b = await context.bookComment.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (b == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                context.Remove(b);
                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }
    }
}
