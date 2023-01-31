using Microsoft.EntityFrameworkCore;
using mustafarbackend.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(
    options => options.UseMySql("Server=localhost;Database=sfe_contatos6;Uid=root;Pwd=Adminmagti*1981", ServerVersion.AutoDetect("Server=localhost;Database=sfe_contatos;Uid=root;Pwd=Adminmagti*1981"))
);

builder.Services.RegisterModules();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRateLimiter();
app.MapEndPoints();
app.Run();
