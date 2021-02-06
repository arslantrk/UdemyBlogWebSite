﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Context;

namespace Ramazan.UdemyBlogWebSite.DataAccess.Migrations
{
    [DbContext(typeof(UdemyBlogWebSiteContext))]
    partial class UdemyBlogWebSiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SurName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.CategoryBlog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("BlogId", "CategoryId")
                        .IsUnique();

                    b.ToTable("CategoryBlogs");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Blog", b =>
                {
                    b.HasOne("Ramazan.UdemyBlogWebSite.Entities.Concreate.AppUser", "AppUser")
                        .WithMany("Blogs")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.CategoryBlog", b =>
                {
                    b.HasOne("Ramazan.UdemyBlogWebSite.Entities.Concreate.Blog", "Blog")
                        .WithMany("CategoryBlogs")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ramazan.UdemyBlogWebSite.Entities.Concreate.Category", "Category")
                        .WithMany("CategoryBlogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Comment", b =>
                {
                    b.HasOne("Ramazan.UdemyBlogWebSite.Entities.Concreate.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ramazan.UdemyBlogWebSite.Entities.Concreate.Comment", "ParentComment")
                        .WithMany("SubComments")
                        .HasForeignKey("ParentCommentId");

                    b.Navigation("Blog");

                    b.Navigation("ParentComment");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.AppUser", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Blog", b =>
                {
                    b.Navigation("CategoryBlogs");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Category", b =>
                {
                    b.Navigation("CategoryBlogs");
                });

            modelBuilder.Entity("Ramazan.UdemyBlogWebSite.Entities.Concreate.Comment", b =>
                {
                    b.Navigation("SubComments");
                });
#pragma warning restore 612, 618
        }
    }
}
