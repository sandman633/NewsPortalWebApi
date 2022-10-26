using AspNetWebApiHomework.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.SocialNetWorkAdministration.Infrastructure;
using WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions;
using WebApi.SocialNetWorkAdministration.Infrastructure.Extensions;

namespace WebApi.SocialNetWorkAdministration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var authoptions = Configuration.GetSection("Auth").Get<JwtTokenConfig>();

            services.AddSingleton(authoptions);

            services.AddScoped<JwtAuthManager>();

            services.RegisterRepository();
            services.RegisterServices();
            services.AddCors(options => options.AddDefaultPolicy(builder => 
                                            builder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()));

            services.DbConfigure(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options =>
                                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
    
            services.AddJwtAuthentification(authoptions);
            services.AddPermissions();


            services.ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI();
            SeedData.Seed(app);
            
        }
    }
}
