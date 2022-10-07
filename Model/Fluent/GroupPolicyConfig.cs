using Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Fluent
{
    public class GroupPolicyConfig : IEntityTypeConfiguration<GroupPolicy>
    {
        public void Configure(EntityTypeBuilder<GroupPolicy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.HasOne(x => x.Group)
                .WithMany(x => x.GroupPolicies)
                .HasForeignKey(x => x.GroupId);
        }
    }
}