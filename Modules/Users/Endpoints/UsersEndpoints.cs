public static class UsersEndPoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/users", () =>
        {
            return new
            {
                horaAtual = DateTime.UtcNow
            };
        })
        .RequireRateLimiting(UsersModules.policyNameRateLimiting);

        routes.MapGet("/teste", () =>
        {
            return new
            {
                horaAtual = DateTime.UtcNow
            };
        });

        routes.MapPost("/users", () =>
        {

        });

        return routes;
    }
}