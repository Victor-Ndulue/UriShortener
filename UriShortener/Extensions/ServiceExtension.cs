using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UriShortener.Data;
using UriShortener.Helpers.FluentValidation.Validations;
using UriShortener.Helpers.Requests;
using UriShortener.Services.Abstractions;
using UriShortener.Services.Implementations;

namespace UriShortener.Extensions;
public static class ServiceExtension
{
    public static void ConfigureCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(opts =>
        {
            opts.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

        });
    }
    public static void ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers(
                    config =>
                    {
                        config.RespectBrowserAcceptHeader = true;
                    })
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    }).AddXmlDataContractSerializerFormatters();
    }
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUriRepo, UriRepo>();
    }
    public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(opts =>
        {
            opts.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings"));
        });
    }
    public static void RegisterFluentValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<GetByUrlDto>, GetByUrlDtoValidation>();
        services.AddScoped<IValidator<AddUriDto>, AddUrlDtoValidation>();
    }
}
