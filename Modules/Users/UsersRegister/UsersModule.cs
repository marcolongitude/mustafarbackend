using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

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
        // services.AddScoped<IUsersRepository, UsersRepository>();


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
            };
            limiterOptions.AddSlidingWindowLimiter(policyName: policyNameRateLimiting, options =>
            {
                options.PermitLimit = 5;
                options.QueueLimit = 1;
                options.SegmentsPerWindow = 10;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.Window = TimeSpan.FromSeconds(30);
            });
        });

        return services;
    }
}