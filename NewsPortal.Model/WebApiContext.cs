using NewsPortal.Model.Domain;
using NewsPortal.Model.Fluent;
using Microsoft.EntityFrameworkCore;

namespace NewsPortal.Model
{
    public class WebApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<GroupPolicy> GroupPolicies { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public WebApiContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NewsConfig());
            builder.ApplyConfiguration(new CommentsConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new GroupPolicyConfig());
            builder.ApplyConfiguration(new UserGroupConfig());
        }

    }
}
