using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace NewsPortal.Model.Fluent
{
    public class CommentsConfig : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.HasIndex(x => x.UserId);

            builder.HasIndex(x => x.NewsId);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Text)
                .IsRequired();

            builder.HasOne(x => x.News)
                .WithMany(x => x.Сomments)
                .HasForeignKey(x => x.NewsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.LinkedComment)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.Property(x => x.Root)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(x => x.CreatedTime)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UpdatedTime)
                .HasDefaultValue(DateTime.Now);


            builder.Property(x => x.CommentState)
                .HasDefaultValue(CommentState.NOTDELETED);
        }
    }
}
