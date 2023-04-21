using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using mustafarbackend.Context;
using mustafarbackend.Mappings;
using mustafarbackend.Middlewares.ErrorHandling;
using Mustafarbackend.Modules.Users.Services;
using Mustafarbackend.Repository;

public class GlobalModule : IModule
{
    // private readonly IConfiguration? _config;

    public IServiceCollection RegisterModule(IServiceCollection services)
    {

        var configMapper = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DtoToModelProfile());
            cfg.AddProfile(new EntityToDtoProfile());
            cfg.AddProfile(new ModelToEntityProfile());
        });

        IMapper mapper = configMapper.CreateMapper();
        services.AddSingleton(mapper);
        services.AddTransient<ExceptionMiddleware>();

        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        // var connectstring = _config["ConnectionString:mysql"];
        var connectstring = "Server=localhost;Database=sfe_contatos6;Uid=root;Pwd=Adminmagti*1981";

        services.AddDbContext<MyContext>(
            options => options.UseMySql(connectstring, ServerVersion.AutoDetect(connectstring))
        );

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
