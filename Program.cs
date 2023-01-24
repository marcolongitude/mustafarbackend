var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterModules();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRateLimiter();
app.MapEndPoints();
app.Run();
