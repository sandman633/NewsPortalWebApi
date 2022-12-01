﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsPortal.Model;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NewsPortal.Model.Migrations
{
    [DbContext(typeof(WebApiContext))]
    [Migration("20221124081017_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NewsPortal.Model.Domain.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("CommentState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("timestamptz");

                    b.Property<int?>("LinkedCommentId")
                        .HasColumnType("integer");

                    b.Property<int>("NewsId")
                        .HasColumnType("integer");

                    b.Property<int>("Root")
                        .HasMaxLength(5)
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamptz");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("LinkedCommentId")
                        .IsUnique();

                    b.HasIndex("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.GroupPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("PolicyType")
                        .HasColumnType("text");

                    b.Property<short>("PolicyValue")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Id");

                    b.ToTable("GroupPolicies");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamptz");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasMaxLength(100)
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("character varying(350)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.HasIndex("PhoneNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.Comments", b =>
                {
                    b.HasOne("NewsPortal.Model.Domain.Comments", "LinkedComment")
                        .WithOne()
                        .HasForeignKey("NewsPortal.Model.Domain.Comments", "LinkedCommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewsPortal.Model.Domain.News", "News")
                        .WithMany("Сomments")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsPortal.Model.Domain.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("LinkedComment");

                    b.Navigation("News");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.GroupPolicy", b =>
                {
                    b.HasOne("NewsPortal.Model.Domain.Group", "Group")
                        .WithMany("GroupPolicies")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.News", b =>
                {
                    b.HasOne("NewsPortal.Model.Domain.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.UserGroup", b =>
                {
                    b.HasOne("NewsPortal.Model.Domain.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsPortal.Model.Domain.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.Group", b =>
                {
                    b.Navigation("GroupPolicies");

                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.News", b =>
                {
                    b.Navigation("Сomments");
                });

            modelBuilder.Entity("NewsPortal.Model.Domain.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("News");

                    b.Navigation("UserGroups");
                });
#pragma warning restore 612, 618
        }
    }
}