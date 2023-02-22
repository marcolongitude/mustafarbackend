using System.Net;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using mustafarbackend.config;
using Mustafarbackend.Modules.Users.Interfaces.Services;
using Mustafarbackend.Modules.Users.Services;

public class UsersModules : IModule
{
    static public readonly string policyNameRateLimiting = "nameRateLimiting";

    public IEndpointRouteBuilder MapEndPoints(IEndpointRouteBuilder endpoints)
    {
        return UsersEndPoints.MapUsersEndpoints(endpoints);
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        // services.AddSingleton(new OrderConfig());
        services.AddTransient<IUserService, UserService>();
        //app.Logger.LogWarning("Rate limit exceeded, retry after {RetryAfter} seconds", retryAfter.TotalSeconds);

        services.AddRateLimiter(limiterOptions =>
        {
            limiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            limiterOptions.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                {
                    await context.HttpContext.Response.WriteAsync(
                        $"Muitos requests feitos. Tente novamente depois " +
                        $"de {retryAfter.TotalMinutes} minuto(s). \n\n" +
                        $"Leia mais sobre nossa política de limites em " +
                        $"https://exemplo.org/docs/ratelimiting",
                        cancellationToken: token
                    );
                }
                else
                {
                    await context.HttpContext.Response.WriteAsync(
                        "Muitos requests feitos. Tente novamente mais tarde. " +
                        "Leia mais sobre o assunto em https://exemplo.org/docs/ratelimiting",
                        cancellationToken: token
                    );
                }
                context.HttpContext.RequestServices.GetService<ILoggerFactory>()?
                    .CreateLogger("Microsoft.AspNetCore.RateLimitingMiddleware")
                    .LogWarning("OnRejected: {GetUserEndPoint}", GetUserEndPoint(context.HttpContext));
            };
            limiterOptions.AddSlidingWindowLimiter(policyName: policyNameRateLimiting, options =>
            {
                options.PermitLimit = MyRateLimitOptions.PermitLimit;
                options.QueueLimit = MyRateLimitOptions.QueueLimit;
                options.SegmentsPerWindow = MyRateLimitOptions.SegmentsPerWindow;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.Window = TimeSpan.FromSeconds(MyRateLimitOptions.Window);
            });

        });

        return services;
    }

    static string GetUserEndPoint(HttpContext context) =>
        $"User {context.User.Identity?.Name ?? "Anonymous"} endpoint:{context.Request.Path}"
        + $" {context.Connection.RemoteIpAddress}";
}

