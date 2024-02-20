using DotnetGenerator;
using DotnetGenerator.Data;
using DotnetGenerator.ZConfig;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Config;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLamar();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(
        builder.Configuration["ConnectionStrings:DefaultConnection"],
        new MySqlServerVersion(new Version(8, 0, 29)))
);

// Add services to the container.
builder.Host.UseLamar((_, registry) => registry.Inject());
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.ConfigCors();

builder.ConfigSecurity();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(CorsConfig.CorsName);

app.Run();