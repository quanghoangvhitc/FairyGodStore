using FairyGodStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    public class ApiBook : ApiBase
    {
        public ApiBook(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var ret = await context.book.ToListAsync();
            //return new ApiResult<User>() 
            //{ 
            //    Status = true, 
            //    ErrMess = new KeyValuePair<string, string>("",""), 
            //    Data = new User() { FullName = "HoàngPQ" }, 
            //    TimeNow = DateTime.Now.Ticks
            //};

            return Ok(new ApiResults<Book>()
            {
                Status = true,
                ErrMess = new KeyValuePair<string, string>("", ""),
                Data = ret,
                TimeNow = DateTime.Now.Ticks
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var ret = await context.book.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(new ApiResult<Book>()
            {
                Status = true,
                ErrMess = new KeyValuePair<string, string>("", ""),
                Data = ret,
                TimeNow = DateTime.Now.Ticks
            });
        }

        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            return Ok(book);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Book book)
        {
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            return Ok(id);
        }
    }
}
