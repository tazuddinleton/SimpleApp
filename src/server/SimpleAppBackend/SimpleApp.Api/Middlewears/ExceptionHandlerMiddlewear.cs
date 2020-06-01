using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SimpleApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SimpleApp.Api.Middlewears
{
    public class ExceptionHandlerMiddlewear
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddlewear(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            // let's say a domain exception will generate a 417 Expectation Failed status code
            catch (DomainException ex)
            {
                await HandleAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        public async Task HandleAsync(HttpContext context, Exception ex)
        {
            // 
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            List<string> errors = new List<string>();
            if (ex is DomainException)
            {
                code = HttpStatusCode.ExpectationFailed;
                errors.AddRange((ex as DomainException).Errors);
            } else 
            {
                errors.Add(ex.Message);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var response = new { Errors = errors, Status = code };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
