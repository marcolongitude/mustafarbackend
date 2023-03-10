using System.Net;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using mustafarbackend.config;
using Security;

public class AuthModule : IModule
{
    static public readonly string policyNameRateLimiting = "nameRateLimiting";

    public IEndpointRouteBuilder MapEndPoints(IEndpointRouteBuilder endpoints)
    {
        return AuthEndPoints.MapAuthEndpoints(endpoints);
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        // services.AddSingleton(new OrderConfig());
        // services.AddScoped<IUsersRepository, UsersRepository>();
        //app.Logger.LogWarning("Rate limit exceeded, retry after {RetryAfter} seconds", retryAfter.TotalSeconds);

        var signingConfigurations = new SigningConfigurations();
        services.AddSingleton(signingConfigurations);

        services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = "marcocpdti@gmail.com";
                paramsValidation.ValidIssuer = "marco@marco";
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

        return services;
    }
}
