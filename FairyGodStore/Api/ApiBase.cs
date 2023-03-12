using FairyGodStore.Models;
using FairyGodStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FairyGodStore.Api.ApiBase;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<object> ApiResponse<T>(Func<Task<ApiResult<T>>> act)
        {
            try
            {
                ApiResult<T> obj = await Task.Run(act);
                return obj;
            }
            catch (Exception ex)
            {
                return new ApiResult<object>(data: null, status: false, errMess: MessageViewModel.SYSTEM_ERROR(ex.ToString()));
            }
        }

        public async Task<object> ApiResponse<T>(Func<Task<ApiResults<T>>> act)
        {
            try
            {
                ApiResults<T> obj = await Task.Run(act);
                return obj;
            }
            catch (Exception ex)
            {
                return new ApiResults<object>(data: null, status: false, errMess: MessageViewModel.SYSTEM_ERROR(ex.ToString()));
            }
        }

        public class ApiResult<T>
        {
            public bool Status { get; set; }
            public KeyValuePair<string, string> ErrMess { get; set; }
            public T Data { get; set; }
            public long TimeNow { get; set; }
            public ApiResult() { }
            public ApiResult(T data, bool status = true, KeyValuePair<string, string> errMess = default)
            {
                Status = status;
                ErrMess = errMess;
                Data = data;
                TimeNow = DateTime.UtcNow.Ticks;
            }
        }

        public class ApiResults<T>
        {
            public bool Status { get; set; }
            public KeyValuePair<string, string> ErrMess { get; set; }
            public List<T> Data { get; set; }
            public long TimeNow { get; set; }
            public ApiResults() { }
            public ApiResults(List<T> data, bool status = true, KeyValuePair<string, string> errMess = default)
            {
                Status = status;
                ErrMess = errMess;
                Data = data;
                TimeNow = DateTime.UtcNow.Ticks;
            }
        }
    }
}
