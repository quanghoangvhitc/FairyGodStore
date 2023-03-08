using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public class ApiResult<T>
        {
            public bool Status { get; set; }
            public KeyValuePair<string, string> ErrMess { get; set; }
            public T Data { get; set; }
            public long TimeNow { get; set; }
        }
    }
}
