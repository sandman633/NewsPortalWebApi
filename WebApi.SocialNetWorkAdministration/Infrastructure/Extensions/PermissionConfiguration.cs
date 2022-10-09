using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.Extensions
{

    public static class PermissionConfiguration 
    {
        /// <summary>
        /// hide services.AddAuthorization(...) with policy configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddPermissions(this IServiceCollection services)
        {
            services.AddAuthorization(options => {

                #region News
                options.AddPolicy("ReadNews", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("News", Permissions.Read ));
                });
                options.AddPolicy("CreateNews", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("News", Permissions.Create));
                });
                options.AddPolicy("UpdateNews", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("News", Permissions.Update));
                });
                options.AddPolicy("DeleteNews", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("News", Permissions.Delete));
                });
                #endregion

                #region Comments
                options.AddPolicy("ReadComments", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("Comments", Permissions.Read));
                });
                options.AddPolicy("CreateComments", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("Comments", Permissions.Create));
                });
                options.AddPolicy("UpdateComments", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("Comments", Permissions.Update));
                });
                options.AddPolicy("DeleteComments", policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement("Comments", Permissions.Delete));
                });
                #endregion
            });
        }
    }
  
}
