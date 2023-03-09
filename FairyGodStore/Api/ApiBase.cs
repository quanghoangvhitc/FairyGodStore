using FairyGodStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FairyGodStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBase : ControllerBase
    {
        private DatabaseContext _context;
        private IConfiguration _configuration;
        internal DatabaseContext context { get => _context; }
        internal IConfiguration configuration { get => _configuration; }
        
        public ApiBase(DatabaseContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public class ApiResult<T>
        {
            public bool Status { get; set; }
            public KeyValuePair<string, string> ErrMess { get; set; }
            public T Data { get; set; }
            public long TimeNow { get; set; }
        }

        public class ApiResults<T>
        {
            public bool Status { get; set; }
            public KeyValuePair<string, string> ErrMess { get; set; }
            public List<T> Data { get; set; }
            public long TimeNow { get; set; }
        }
    }
}
