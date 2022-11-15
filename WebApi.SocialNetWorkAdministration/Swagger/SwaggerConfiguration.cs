using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace NewsPortal.WebApi.Swagger
{
    /// <summary>
    /// Описывает конфигурацию сваггера
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Настраиваем документ свагера
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("News", new OpenApiInfo { });
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API", Description = "Web API for social network" });
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Name = "Authorization",
                    Description = "Bearer authorize",
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference{ Id="Bearer", Type=ReferenceType.SecurityScheme}
                        },
                        new string[] { }
                    }
                });
            });
            //services.AddSwaggerDocument(config => {
            //    config.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
            //        new OpenApiSecurityScheme
            //        {
            //            Type = OpenApiSecuritySchemeType.ApiKey,
            //            Name = "Authorization",
            //            Description = "Copy 'Bearer ' + valid JWT token into field",
            //            In = OpenApiSecurityApiKeyLocation.Header,
            //        }));
            //});
            //services.AddSwaggerDocument(c =>
            //{
            //    c.Title = "News";
            //    c.DocumentName = SwagDocParts.News;
            //    c.ApiGroupNames = new[] { SwagDocParts.News};
            //    c.GenerateXmlObjects = true;
            //});
            //services.AddSwaggerDocument(c =>
            //{
            //    c.Title = "User";
            //    c.DocumentName = SwagDocParts.User;
            //    c.ApiGroupNames = new[] { SwagDocParts.User};
            //    c.GenerateXmlObjects = true;
            //});
            //services.AddSwaggerDocument(c =>
            //{
            //    c.Title = "Comments";
            //    c.DocumentName = SwagDocParts.Comments;
            //    c.ApiGroupNames = new[] { SwagDocParts.Comments };
            //    c.GenerateXmlObjects = true;
            //});
        }
    }
}
