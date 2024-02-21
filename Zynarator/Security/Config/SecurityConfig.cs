using System.Text;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DotnetGenerator.Zynarator.Security.Config;

public static class SecurityConfig
{
    public static void ConfigSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity();
        builder.Services.ConfigIdentity();
        builder.ConfigJwt();
    }

    private static void AddIdentity(this IServiceCollection service)
    {
        service.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    private static void ConfigIdentity(this IServiceCollection service)
    {
        service.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.SignIn.RequireConfirmedEmail = false;
        });
    }

    private static void ConfigJwt(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = JwtParams.ValidIssuer,
                    ValidAudience = JwtParams.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtParams.Secret))
                };
            });
    }
}