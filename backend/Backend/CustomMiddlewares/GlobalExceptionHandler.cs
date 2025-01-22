
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;
using System.Text;

namespace Backend.CustomMiddlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        //private readonly RequestDelegate _next;
        //public GlobalExceptionHandler(RequestDelegate next)
        //{
        //        _next = next;
        //}
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                //await _next(context);
                await next(context);
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                   await LogExceptionToFile(ex);
                    context.Response.StatusCode=Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An Error Occured while processing the request");

                }
            }
        }

        private async Task LogExceptionToFile(Exception ex)
        {
            string RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot", "ExceptionLogs");
            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
            }
            string logFilePath = Path.Combine(RootPath, $"ExceptionLog_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}");
            //Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));


            StringBuilder logcontent=new StringBuilder();
            logcontent.AppendLine("-------------Exception Details-------------");
            logcontent.AppendLine($"TimeStamp :{DateTime.UtcNow}");
            logcontent.AppendLine($"Message: {ex.Message}");
            logcontent.AppendLine($"Stack Trace:{ex.StackTrace}");
            if (ex.InnerException != null) {
                logcontent.AppendLine($"Inner Exception :{ex.InnerException}");
            }
            logcontent.AppendLine("--------------------------");
            logcontent.AppendLine();
            await File.AppendAllTextAsync(logFilePath, logcontent.ToString());
        }
    }
   public static class GlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder HandleException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
