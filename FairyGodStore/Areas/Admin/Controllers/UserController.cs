using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Areas.Admin.Controllers
{
    public class UserController : AdminBase
    {
        public UserController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        public IActionResult Index()
        {

            return View("Views/Admin/Index.cshtml");
        }
    }
}
