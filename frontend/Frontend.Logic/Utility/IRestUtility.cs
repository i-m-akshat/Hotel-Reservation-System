using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Utility
{
    public interface IRestUtility<T>
    {
        Task<T> GetByIDAsync(string BaseUrl, string RequestUrl, string id);
        Task<T> GetAsync_Count(string BaseUrl, string RequestUrl, string count);
        Task<T> PostAsync(string BaseUrl,string RequestUrl,string Content);
        Task<T> GetAsync(string BaseUrl, string RequestUrl);
        Task<T> PutAsync(string BaseUrl,string RequestUrl,string id,string Content);  
        Task<T> DeleteAsync(string BaseUrl,string RequestUrl,string id);
    }
    
}
