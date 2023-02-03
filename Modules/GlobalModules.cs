using Microsoft.OpenApi.Models;

public class GlobalModule: IModule
{
    public IEndpointRouteBuilder MapEndPoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
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
