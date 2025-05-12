using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Connections.Features;
using Services.Contracts;
using WebApplication1.Exceptions;

namespace WebApplication1.Extensions;

public static class ExceptionMiddlewareExtension
{
   
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerServices logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionFeature != null)
                {
                    context.Response.StatusCode = exceptionFeature.Error switch
                    {
                        BookNotFound _ => (int)HttpStatusCode.NotFound,
                        _ => (int)HttpStatusCode.InternalServerError
                    };
                    logger.LogError($"Something went wrong: {exceptionFeature.Error}");
                    var response = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = exceptionFeature.Error.Message
                    };
                    var jsonResponse = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(jsonResponse);
                }
            });
        });
    
}
}