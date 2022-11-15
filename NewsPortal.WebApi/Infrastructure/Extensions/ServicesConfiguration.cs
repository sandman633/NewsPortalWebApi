using NewsPortal.BusinessLogic.Services;
using NewsPortal.BusinessLogic.Services.Implementations;
using NewsPortal.BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.BusinessLogic.Services.Implementations;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebApi.Infrastructure.Extensions
{
    public static class ServicesConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IGroupPolicyService, GroupPolicyService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<INewsService, NewsService>();
        }
    }
}
