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

        [HttpGet("bookcontent/{id}")]
        public async Task<IActionResult> Index(long id)
        {
            var bookcontents = await context.bookContent.Where(b => b.Id == id).ToListAsync();

            return View(bookcontents);
        }
    }
}
