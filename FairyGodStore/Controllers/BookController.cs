using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FairyGodStore.Controllers
{
    public class BookController : BaseController
    {
        public BookController(DatabaseContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
