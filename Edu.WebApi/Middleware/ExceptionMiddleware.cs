using Edu.WebApi.Extensions;
using Edu.WebApi.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Edu.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private async Task InvokeAsync(HttpContext context)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();

            var exception = feature.Error;


            var response = new ApiResponse
            {
                HasError = true
            };
            if (exception is BadHttpRequestException badHttp)
            {
                response.Message = "invalid request";
                response.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
                        BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttp);
            }
            else
            {
                response.Message = "error occured";
                response.Status = 500;
            }

            context.Response.WriteJson(response, "application/problem+json");
            context.Response.StatusCode = response.Status;

            await _next(context);
        }
    }
}
