using System;
using System.Collections.Generic;

namespace WebAPI.Model.Utilities
{
    public class ResponseResult<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<String> Errors { get; set; }
        public T Data { get; set; } = default;
    }
}
