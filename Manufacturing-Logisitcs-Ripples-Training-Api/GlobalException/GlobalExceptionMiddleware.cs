using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.Exceptions;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.GlobalExceptions
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            switch (exception)
            {
                case GlobalException globalEx:
                    statusCode = globalEx.StatusCode;
                    break;

                case DispatchNotFoundException:
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;

                case DispatchManagementException:
                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
