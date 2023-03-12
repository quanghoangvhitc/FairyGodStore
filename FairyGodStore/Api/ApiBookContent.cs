using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace FairyGodStore.Api
{
    [Route("api/bookcontent")]
    public class ApiBookContent : ApiBase
    {
        public ApiBookContent(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var ret = await context.bookContent.SingleOrDefaultAsync(b => b.Id.Equals(id));
                return new ApiResult<BookContent>(data: ret, errMess: ret == null ? MessageViewModel.DATA_EMPTY : default);
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookContent bookContent)
        {
            return Ok(await ApiResponse(async () =>
            {
                await context.bookContent.AddAsync(bookContent);
                await context.SaveChangesAsync();
                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] BookContent bookContent)
        {
            return Ok(await ApiResponse(async () =>
            {
                if (id != bookContent.Id)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_VALID());

                var db = await context.bookContent.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (db == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                db.Chapter = bookContent.Chapter;
                db.Content = bookContent.Content;
                db.ReleaseDate = bookContent.ReleaseDate;
                db.ModifiedBy = bookContent.ModifiedBy;
                db.Modified = bookContent.Modified;

                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            return Ok(await ApiResponse(async () =>
            {
                var b = await context.bookContent.SingleOrDefaultAsync(b => b.Id.Equals(id));
                if (b == null)
                    return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.DATA_EMPTY);

                context.Remove(b);
                await context.SaveChangesAsync();

                return new ApiResult<object>(data: null, status: true);
            }));
        }
    }
}
