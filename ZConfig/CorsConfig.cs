namespace DotnetGenerator.ZConfig;

public static class CorsConfig
{
    public const string CorsName = "CorsPolicy";
    private const string Origin = "http://localhost:3000";

    public static void ConfigCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsName,
                policyBuilder =>
                {
                    policyBuilder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(Origin)
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition")
                        .SetPreflightMaxAge(TimeSpan.FromMinutes(5))
                        .Build();
                });
        });
    }
}