using Microsoft.Extensions.DependencyInjection;
using Repositories.Implementations;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SocialNetWorkAdministration.Infrastructure.Extensions
{

    public static class RepositoryConfiguration
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IGroupPolicyRepository, GroupPolicyRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
        }
    }
}
