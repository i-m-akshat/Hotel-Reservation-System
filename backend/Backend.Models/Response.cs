using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; } 
        public string StatusMessage { get; set; }
        public T Data { get; set; }
        
        public List<String> Errors { get; set; }
    }
    public class ResponseGet<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
        public T Data { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<String> Errors { get; set; }
    }
}
