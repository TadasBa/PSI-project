using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using BackendAPI.Middleware;
using BackendAPI.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDBContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("mssql")).AddInterceptors(new DatabaseInterceptor()));
builder.Services.AddTransient<ILogService, LogService>();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

app.UseForwardedHeaders();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LogMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();

public partial class Program { }
