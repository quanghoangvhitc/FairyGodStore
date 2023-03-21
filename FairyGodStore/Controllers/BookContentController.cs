using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Controllers
{
    public class BookContentController : BaseController
    {
        public BookContentController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet("/bookcontent/{id}")]
        public async Task<IActionResult> Index(long id)
        {
            var bookchapter = await context.bookChapter.Include(bch=>bch.bookcontent).Where(b=>b.Id == id).SingleOrDefaultAsync();
            var book = await context.book.Where(b => b.Id == bookchapter.BookId).SingleOrDefaultAsync();

            ViewBag.Title = book.Title;

            return View(bookchapter);
        }
    }
}
