using AspNetWebApiHomework.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions;
using WebApi.SocialNetWorkAdministration.Infrastructure.Extensions;
using WebApi.SocialNetWorkAdministration.Infrastructure.Mapping;

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
            var authOptions = Configuration.GetSection("Auth");
            services.Configure<AuthOption>(authOptions);
            services.RegisterServices();
            services.AddCors(options => options.AddDefaultPolicy(builder => 
                                            builder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()));

            services.ConfigurationDb(Configuration);
            services.AddAutoMapper(config => config.AddProfile<UserProfile>());
            services.AddControllers().AddNewtonsoftJson(options =>
                                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            var authoptions = Configuration.GetSection("Auth").Get<AuthOption>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authoptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authoptions.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = authoptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });
            services.ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,SeedDb seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //seed.Seed();
        }
    }
}
