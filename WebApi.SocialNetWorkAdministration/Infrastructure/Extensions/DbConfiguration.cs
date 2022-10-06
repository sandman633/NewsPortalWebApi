using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.Extensions
{
    public static class DbConfiguration
    {
        public static void DbConfigure(this IServiceCollection services,IConfiguration configuration)
        {
            //services.AddDbContext<WebApiContext>(options => 
            //options.UseNpgsql(configuration.GetConnectionString(nameof(WebApiContext)), 
            //builder => builder.MigrationsAssembly(typeof(WebApiContext).Assembly.FullName)));
            services.AddDbContext<WebApiContext>(options =>
            options.UseInMemoryDatabase("TestDataBase"));

        }
    }
}
