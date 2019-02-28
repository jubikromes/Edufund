using Edu.WebApi.Extensions;
using Edu.WebApi.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Edu.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionMiddleware(RequestDelegate next)
        {
            request = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public Task Invoke(HttpContext context) => this.InvokeAsync(context);
        private async Task InvokeAsync(HttpContext context)
        {
        
        //var feature = context.Features.Get<IExceptionHandlerFeature>();

        //var exception = feature.Error;


            var response = new ApiResponse
            {
            };
            try
            {
                await request(context);
            }
            catch (Exception exception)
            {
                response.HasError = true;

                var httpStatusCode = ConfigurateExceptionTypes(exception);
                response.Message = exception.Message;
                response.Status = 500;
                context.Response.StatusCode = httpStatusCode;
                context.Response.ContentType = "application/json";
                context.Response.WriteJson(response);
                context.Response.StatusCode = response.Status;
                context.Response.Headers.Clear();
            }
            
        }

        private static int ConfigurateExceptionTypes(Exception exception)
            {
                int httpStatusCode;

                // Exception type To Http Status configuration 
                switch (exception)
                {
                    case var _ when exception is ValidationException:
                        httpStatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        httpStatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                return httpStatusCode;
            }
    }
}
