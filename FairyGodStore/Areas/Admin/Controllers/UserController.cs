using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Areas.Admin.Controllers
{
    public class UserController : AdminBase
    {
        public override IActionResult Index()
        {
            return View("Views/Admin/Index.cshtml");
        }
    }
}
