using System.Text.Json.Serialization;
using DotnetGenerator;
using DotnetGenerator.Data;
using DotnetGenerator.ZConfig;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLamar();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

const string connectionString = "server=localhost;user=root;password=;database=stocky";
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 29)))
    );

// Add services to the container.
builder.Host.UseLamar((_, registry) => registry.InjectServices().InjectRepositories());
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(CorsConfig.CorsName);

app.Run();
