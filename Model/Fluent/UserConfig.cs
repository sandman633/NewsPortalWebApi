using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewsPortal.Model.Fluent
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x=>x.Id);

            builder.HasIndex(x => x.PhoneNumber);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired(false)
                .HasMaxLength(100);


            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(350);

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Age)
                .IsRequired(false)
                .HasMaxLength(100);
        }
    }
}
