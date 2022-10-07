using Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Fluent
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.GroupName)
                .HasMaxLength(50);

        }
    }
}
