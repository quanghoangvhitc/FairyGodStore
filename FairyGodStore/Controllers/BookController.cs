using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

        public IActionResult InputBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InputBook(BookViewModel bookViewModel, IFormFile postedFile)
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
                    ReleaseDate = bookViewModel.ReleaseDate.Millisecond,
                    CreatedBy = userId,
                    Created = timeNow,
                    ModifiedBy = userId,
                    Modified = timeNow,
                    Views = 0,
                    Point = 0,
                    Thumbnail = filePath
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
