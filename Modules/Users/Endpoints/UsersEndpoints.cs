using Api.Application.Controllers;

public static class UsersEndPoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder routes)
    {
        var controller = new UserController();
        routes.MapGet("/users", async () =>
        {
            var result = await controller.GetAll();
            return new
            {
                result
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