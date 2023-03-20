using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace FairyGodStore.Areas.Admin.Controllers
{
    [Route("admin/book")]
    public class BookController : AdminBase
    { 
        public BookController(DatabaseContext context, IConfiguration configuration) : base(context, configuration) { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await context.book.ToListAsync();

            return View(books);
        }

        [Authorize(Roles = $"{SecurityRoles.Admin},{SecurityRoles.Manager}")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = $"{SecurityRoles.Admin},{SecurityRoles.Manager}")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(BookViewModel bookViewModel, IFormFile postedFile)
        {
            string filePath = string.Empty;
            try
            {
                long userId = GetUserId();
                if (userId <= 0)
                    Redirect("/book/error");

                string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(postedFile.FileName);
                filePath = Path.Combine(@"image\bookcover", fileName);
                string dicPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image\bookcover");
                string path = Path.Combine(dicPath, fileName);

                if (!Directory.Exists(dicPath))
                    Directory.CreateDirectory(dicPath);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await postedFile.CopyToAsync(fileStream);
                }

                long timeNow = DateTime.UtcNow.Ticks;
                Book book = new Book()
                {
                    Title = bookViewModel.Title,
                    Author = bookViewModel.Author,
                    SortDescription = bookViewModel.SortDescription,
                    PublicationDate = bookViewModel.PublicationDate,
                    CreatedBy = userId,
                    Created = timeNow,
                    ModifiedBy = userId,
                    Modified = timeNow,
                    Views = 0,
                    Point = 0,
                    Thumbnail = filePath,
                    LinkData = bookViewModel.LinkData
                };

                await context.book.AddAsync(book);
                await context.SaveChangesAsync();
            }
            catch
            {
                if (!filePath.IsEmpty())
                {
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }
                Redirect("/book/error");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
