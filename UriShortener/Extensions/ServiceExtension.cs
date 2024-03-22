using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UriShortener.Data;
using UriShortener.Helpers.FluentValidation.ValidationExtension;
using UriShortener.Helpers.FluentValidation.Validations;
using UriShortener.Helpers.Requests;
using UriShortener.Services.Abstractions;
using UriShortener.Services.Implementations;

namespace UriShortener.Extensions;
public static class ServiceExtension
{
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
