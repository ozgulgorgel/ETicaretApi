using ETicaretAPI.Persistence.Contexts;
using System;
using Newtonsoft.Json;
using System.Net;

namespace ETicaretApi.WEBAPI.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ETicaretAPIDBContext _context;

        public ExceptionMiddleware(ETicaretAPIDBContext context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ETicaretApi.Domain.Entities.Exception exception=new ETicaretApi.Domain.Entities.Exception
                {
                    CreatedAt = DateTime.Now,
                    InnerException = "fvb",
                    StackTrace = ex.StackTrace,
                    Message = ex.Message,
                    Path = context.Request.Path,
                    Id=Guid.NewGuid(),  
                    CreatedDate=DateTime.Now  

                };

                await _context.Exceptions.AddAsync(exception);
                var sonuc=  await _context.SaveChangesAsync();

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = ex.Message }));
            }
        }
    }
}
