using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Controllers
{
    public class BookChapterController : BaseController
    {
        public BookChapterController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet("/bookchapter/{id}")]
        public async Task<IActionResult> Index(long id)
        {
            var bookChapters = await context.bookChapter.Where(b => b.BookId == id).ToListAsync();
            if (bookChapters.Count > 0)
            {
                var book = await context.book.Where(b => b.Id == bookChapters[0].BookId).SingleOrDefaultAsync();

                ViewBag.Title = book.Title;
            }

            return View(bookChapters);
        }
    }
}
