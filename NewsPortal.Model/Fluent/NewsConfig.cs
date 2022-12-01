using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace NewsPortal.Model.Fluent
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Сomments)
                .WithOne(x => x.News)
                .HasForeignKey(x => x.NewsId);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Text)
                .IsRequired();

            builder.Property(x => x.CreatedTime)
                .HasColumnType("timestamptz")
                .IsRequired(false);

            builder.Property(x => x.UpdatedTime)
                .HasColumnType("timestamptz")
                .IsRequired(false);

        }
    }
}
