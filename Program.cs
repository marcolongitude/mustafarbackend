using Microsoft.EntityFrameworkCore;
using mustafarbackend.Context;

var builder = WebApplication.CreateBuilder(args);
var connectstring = builder.Configuration["ConnectionString:mysql"];

builder.Services.AddDbContext<MyContext>(
    options => options.UseMySql(connectstring, ServerVersion.AutoDetect(connectstring))
);

builder.Services.RegisterModules();
            
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/", () => "Hello World!");

app.UseRateLimiter();
app.UseAuthorization();
app.MapEndPoints();
app.Run();
