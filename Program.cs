var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterModules();
builder.Services.AddControllers();
            
var app = builder.Build();
app.UseRateLimiter();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.Run();
