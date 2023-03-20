using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Controllers
{
    public class BookController : BaseController
    {
        public BookController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet("book")]
        public async Task<IActionResult> Index()
        {
            var books = await context.book.ToListAsync();

            return View(books);
        }
    }
}
