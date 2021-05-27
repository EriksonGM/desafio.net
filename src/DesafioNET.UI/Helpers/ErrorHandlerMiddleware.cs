using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DesafioNET.Services.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DesafioNET.UI.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string msg;

                switch (error)
                {
                    case NotFoundException _:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        msg = JsonSerializer.Serialize(new { message = error?.Message });
                        break;

                    case BadRequestException _:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        msg = JsonSerializer.Serialize(new { message = error?.Message });
                        break;

                    case UnauthorizedException _:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        msg = JsonSerializer.Serialize(new { message = error?.Message });
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        msg = JsonSerializer.Serialize(new { message = "Somethings went wrong" });
                        _logger.LogError(error, error.Message, context.Request.Body);
                        break;
                }

                /*
                switch (error)
                {
                    //case AppException e:
                    //    // custom application error
                    //    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //    break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                */
                //var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(msg);
            }
        }
    }
}
