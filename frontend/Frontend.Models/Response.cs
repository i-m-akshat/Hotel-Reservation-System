using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
        public T Data { get; set; }
        public List<String> Errors { get; set; }
    }
}
