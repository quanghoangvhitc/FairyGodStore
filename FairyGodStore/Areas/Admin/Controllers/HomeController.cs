using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Areas.Admin.Controllers
{
    public class HomeController : AdminBase
    {
        public override IActionResult Index()
        {
            return View("Views/Admin/Home.cshtml");
        }
    }
}
