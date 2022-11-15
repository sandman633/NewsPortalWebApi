using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.WebApi.Infrastructure.AuthOptions;

namespace NewsPortal.WebApi.Infrastructure.Extensions
{
    public static class AuthConfiguration
    {
        /// <summary>
        /// Настройка jwt аутентификации
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="jwtTokenConfig">Конфиг токена из настроек приложения</param>
        public static void AddJwtAuthentification(this IServiceCollection services, JwtTokenConfig jwtTokenConfig)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtTokenConfig.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = jwtTokenConfig.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
        }

    }

}
