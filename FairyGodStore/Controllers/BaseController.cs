using FairyGodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FairyGodStore.Controllers
{
    public class BaseController : Controller
    {
        private DatabaseContext _context;
        private IConfiguration _configuration;
        internal DatabaseContext context { get => _context; }
        internal IConfiguration configuration { get => _configuration; }

        public BaseController(DatabaseContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }
    }
}
