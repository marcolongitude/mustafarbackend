public static class AuthEndPoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/login", () =>
        {
            return new
            {
                horaAtual = DateTime.UtcNow
            };
        });

        return routes;
    }
}