using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Areas.Admin.Controllers
{
    public class HomeController : AdminBase
    {
        public HomeController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        public IActionResult Index()
        {
            ViewBag.brand = "Admin";
            return View();
        }
    }
}
