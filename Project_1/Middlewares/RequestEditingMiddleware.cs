using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Project_1.Middlewares
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;

        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().Equals("/ramo"))
            {
                await context.Response.WriteAsync("welcome ramo");
            }
            else
            {
                await _requestDelegate.Invoke(context);
            }
      
        }
    }
}
