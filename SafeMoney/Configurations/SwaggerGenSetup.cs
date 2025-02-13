using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace SafeMoneyAPI.Configurations
{
    public static class SwaggerGenSetup
    {
        public static void AddSwaggerGenSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "SafeMoneyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
    }
}
