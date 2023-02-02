using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using mustafarbackend.Context;

var builder = WebApplication.CreateBuilder(args);
var connectstring = builder.Configuration["ConnectionString:mysql"];

builder.Services.AddDbContext<MyContext>(
    options => options.UseMySql(connectstring, ServerVersion.AutoDetect(connectstring))
);

builder.Services.RegisterModules();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SoFálta.eu Contatos",
                    Description = "Lista de usuários para qualidade de atendimento ao cliente",
                    TermsOfService = new Uri("https://sofalta.eu/privacy")
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });

            
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
