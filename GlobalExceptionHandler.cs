﻿using Microsoft.AspNetCore.Diagnostics;
using MoneyMe.Api.Source.Domain.BusinessRules;
using Newtonsoft.Json;
using System.Net;

namespace MoneyMe.Api
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public static class GlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string errorJson;
                        var message = "Internal server error";
                        if (contextFeature.Error is BusinessRuleException)
                        {
                            var error = (BusinessRuleException)contextFeature.Error;
                            context.Response.StatusCode = (int)error.StatusCode;
                            errorJson = JsonConvert.SerializeObject(new ErrorDetails()
                            {
                                statusCode = (int)error.StatusCode,
                                message = error.Message
                            });
                            await context.Response.WriteAsync(errorJson);
                        }
                        else
                        {
                            errorJson = JsonConvert.SerializeObject(new ErrorDetails()
                            {
                                statusCode = 500,
                                message = message
                            });
                            await context.Response.WriteAsync(errorJson);

                            logger.LogError(message, contextFeature.Error);
                        }
                    }
                });
            });
        }
    }
}
