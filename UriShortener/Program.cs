using FluentValidation.AspNetCore;
using UriShortener.Extensions;
using UriShortener.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterFluentValidation();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddControllers();
builder.Services.RegisterServices();
builder.Services.ConfigureDataContext(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();