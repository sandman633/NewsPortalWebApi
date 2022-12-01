using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsPortal.WebApi.Infrastructure;
using NewsPortal.WebApi.Infrastructure.AuthOptions;
using NewsPortal.WebApi.Infrastructure.Extensions;
using NewsPortal.WebApi.Middlewares;
using NewsPortal.WebApi.Swagger;

namespace NewsPortal.WebApi
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
            services.DbConfigure(Configuration);

            services.RegisterRepository();
            services.RegisterServices();
            services.AddCors(options => options.AddDefaultPolicy(builder =>
                                            builder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()));

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

            app.UseMiddleware<ExceptionHandlerMiddleware>();

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
