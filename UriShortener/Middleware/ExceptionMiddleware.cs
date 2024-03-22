using Microsoft.AspNetCore.Diagnostics;

namespace UriShortener.Middleware;

public static class ExceptionMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseHttpLogging();
        app.UseExceptionHandler(
            appError => appError.Run(
                async context => 
                { 
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(exceptionFeature is not null)
                    {
                        var error = exceptionFeature.Error;
                        var endPoint = exceptionFeature.Endpoint;
                        var logger = context.Features.Get<ILogger>();
                        //logger.LogError($"An error occurred processing request {endPoint}.", error);
                        await context.Response.WriteAsJsonAsync(new ErrorDetails
                        {
                            StatusCode = 500,
                            Message = $"An error encountered. Details: {error.Message}"
                        });
                    }
                })
            ); 
    }
}
public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}