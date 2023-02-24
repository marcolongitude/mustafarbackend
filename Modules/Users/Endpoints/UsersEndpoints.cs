// using Api.Application.Controllers;
// using Mustafarbackend.Modules.Users.Interfaces.Services;
// using Mustafarbackend.Modules.Users.Services;

// public static class UsersEndPoints
// {
//     public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder routes)
//     {
//         routes.MapGet("/users", async () =>
//         {
//             var result = await controller.GetAll();
//             return new
//             {
//                 result
//             };
//         })
//         .RequireRateLimiting(UsersModules.policyNameRateLimiting);

//         routes.MapGet("/teste", () =>
//         {
//             return new
//             {
//                 horaAtual = DateTime.UtcNow
//             };
//         });

//         routes.MapPost("/users", () =>
//         {

//         });

//         return routes;
//     }
// }