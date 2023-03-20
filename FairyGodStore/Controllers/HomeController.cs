using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FairyGodStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FairyGodStore.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<IActionResult> Index()
        {
            ViewBag.brand = "Home";

            var books = await context.book.ToListAsync();

            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
