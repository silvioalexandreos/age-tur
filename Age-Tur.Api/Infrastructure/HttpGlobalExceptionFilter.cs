using Age_Tur.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;

namespace Age_Tur.Api.Infrastructure
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
               context.Exception,
               context.Exception.Message);

            var isHttpStatusException = context.Exception.GetType().IsAssignableTo(typeof(HttpStatusException));
            if (isHttpStatusException)
            {
                var ex = (HttpStatusException)context.Exception;
                context.Result = ex.CreateObjectResult();
                context.HttpContext.Response.StatusCode = (int)ex.StatusCode;
            }
            else
            {
                var json = new JsonErrorResponse();
                if (_env.IsDevelopment())
                {
                    json.DeveloperMeesage = context.Exception;
                }
                json.Messages.Add("servidor", new List<string> { "Ocorreu uma falha interna no servidor." });
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
            context.HttpContext.Response.ContentType = "application/json";
        }
    }
}
