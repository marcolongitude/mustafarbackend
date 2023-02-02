using Microsoft.EntityFrameworkCore;
using mustafarbackend.Context;

var builder = WebApplication.CreateBuilder(args);
var connectstring = builder.Configuration["ConnectionString:mysql"];

builder.Services.AddDbContext<MyContext>(
    options => options.UseMySql(connectstring, ServerVersion.AutoDetect(connectstring))
);

builder.Services.RegisterModules();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRateLimiter();
app.MapEndPoints();
app.Run();
