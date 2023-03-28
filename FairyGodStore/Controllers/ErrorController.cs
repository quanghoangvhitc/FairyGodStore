using System;
using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FairyGodStore.Controllers
{
	public class ErrorController : BaseController
	{
        public ErrorController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet("error/404")]
        public IActionResult PageNotFound()
        {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath"))
                originalPath = HttpContext.Items["originalPath"] as string;

            return View();
        }
    }
}

