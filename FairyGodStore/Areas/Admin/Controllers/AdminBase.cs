using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public abstract class AdminBase : Controller
    {
        public abstract IActionResult Index();
    }
}
