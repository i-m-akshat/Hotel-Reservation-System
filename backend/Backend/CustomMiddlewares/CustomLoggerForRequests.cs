using System.Text;

namespace Backend.CustomMiddlewares
{
    public class CustomLoggerForRequests:IMiddleware
    {
        //private readonly RequestDelegate _next;
        //public CustomLoggerForRequests(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public async Task InvokeAsync(HttpContext context,IServiceProvider serviceProvider) {
        //    try
        //    {

        //        string logPath = Path.Combine(Directory.GetCurrentDirectory(), $"RequestLog{DateTime.UtcNow}");
        //        StringBuilder logContext = new StringBuilder();
        //        logContext.AppendLine($"-------------------Log_{DateTime.UtcNow}-------------------");

        //        logContext.AppendLine("-------------------Request Part-------------------");
        //        logContext.AppendLine($"Request Path:{context.Request.Path}");
        //        logContext.AppendLine($"Request Method:{context.Request.Method}");
        //        logContext.AppendLine($"Request Headers:{context.Request.Headers}");
        //        logContext.AppendLine($"Request Body:{context.Request.Body}");
        //        logContext.AppendLine($"Request Host:{context.Request.Host}");
        //        logContext.AppendLine($"Request ContentType:{context.Request.ContentType}");
        //        logContext.AppendLine("-------------------------- -----------------------");
        //        logContext.AppendLine("-------------------Response Part-------------------");
        //        logContext.AppendLine($"Response status:{context.Response.StatusCode}");
        //        logContext.AppendLine($"Response Headers:{context.Response.Headers}");
        //        logContext.AppendLine($"Response Body:{context.Response.Body}");
        //        logContext.AppendLine($"Response ContentType:{context.Response.ContentType}");
        //        await _next(context);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        //GlobalExceptionHandler global=new GlobalExceptionHandler();
        //        //global.InvokeAsync(context,_next);
        //        var global = serviceProvider.GetRequiredService<GlobalExceptionHandler>();
        //        await global.InvokeAsync(context,_next);
        //        await _next(context);
        //    }
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                string RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot", "RequestLogs");
                if (!Directory.Exists(RootPath)){
                    Directory.CreateDirectory(RootPath);
                }
                string logPath = Path.Combine(RootPath, $"RequestLog{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}");
                StringBuilder logContext = new StringBuilder();
                logContext.AppendLine($"-------------------Log_{DateTime.UtcNow}-------------------");

                logContext.AppendLine("-------------------Request Part-------------------");
                logContext.AppendLine($"Request Path:{context.Request.Path}");
                logContext.AppendLine($"Request Method:{context.Request.Method}");
                logContext.AppendLine($"Request Headers:{context.Request.Headers}");
              
                logContext.AppendLine($"Request Body:{context.Request.Body}");
                logContext.AppendLine($"Request Host:{context.Request.Host}");
                logContext.AppendLine($"Request ContentType:{context.Request.ContentType}");
                logContext.AppendLine("-------------------------- -----------------------");
                logContext.AppendLine("-------------------Response Part-------------------");
                logContext.AppendLine($"Response status:{context.Response.StatusCode}");
                logContext.AppendLine($"Response Headers:{context.Response.Headers}");
                //string body=string.Empty;
                //if (context.Response.Body != null)
                //{
                //    context.Response.Body.Seek(0, SeekOrigin.Begin);
                //    var text=await new StreamReader(context.Response.Body).ReadToEndAsync();
                //    context.Response.Body.Seek(0,SeekOrigin.Begin); 
                //    body = text;
                //    //using (var reader = new StreamReader(context.Response.Body, encoding: Encoding.UTF8, false,leaveOpen:true)) 

                //    //{ 
                //    //body=reader.ReadToEnd();
                //    //}
                //}
                logContext.AppendLine($"Response Body:{context.Response.Body}");
                //logContext.AppendLine($"Response Body:{body}");
                logContext.AppendLine($"Response ContentType:{context.Response.ContentType}");
               
                await File.AppendAllTextAsync( logPath, logContext.ToString() );
                //if (!File.GetAttributes(logPath).HasFlag(FileAttributes.ReadOnly))
                //{
                //    File.SetAttributes(logPath, FileAttributes.ReadOnly);
                //}

                await next(context);
            }
            catch (Exception ex)
            {
                //GlobalExceptionHandler global=new GlobalExceptionHandler();
                //global.InvokeAsync(context,_next);

                //var global = serviceProvider.GetRequiredService<GlobalExceptionHandler>();
                var global = new GlobalExceptionHandler();
                await global.InvokeAsync(context, next);
                await next(context);
            }
        }
    }
    public static class CustomLoggerForRequestExtension
    {
        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder app)
        {
           return app.UseMiddleware<CustomLoggerForRequests>();
        }
    }
}
