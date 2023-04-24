using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using mustafarbackend.Modules.Auth.Interfaces.Services;
using Security;
using Services;

public class AuthModule : IModule
{
    static public readonly string policyNameRateLimiting = "nameRateLimiting";

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IAuthenticateService, LoginService>();

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
