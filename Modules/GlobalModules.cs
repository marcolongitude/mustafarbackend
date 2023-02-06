using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using mustafarbackend.Context;

public class GlobalModule: IModule
{
    private readonly IConfiguration? _config;

    public IEndpointRouteBuilder MapEndPoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        if(_config is not null){
            var connectstring = _config["ConnectionString:mysql"];

            services.AddDbContext<MyContext>(
                options => options.UseMySql(connectstring, ServerVersion.AutoDetect(connectstring))
            );
        }

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
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
        return services;
    }
}
