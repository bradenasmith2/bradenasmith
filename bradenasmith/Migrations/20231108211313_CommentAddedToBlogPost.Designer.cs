﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bradenasmith.DataAccess;

#nullable disable

namespace bradenasmith.Migrations
{
    [DbContext(typeof(bradenasmithContext))]
    [Migration("20231108211313_CommentAddedToBlogPost")]
    partial class CommentAddedToBlogPost
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bradenasmith.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("SecFiveContent")
                        .HasColumnType("text")
                        .HasColumnName("sec_five_content");

                    b.Property<string>("SecFiveTitle")
                        .HasColumnType("text")
                        .HasColumnName("sec_five_title");

                    b.Property<string>("SecFourContent")
                        .HasColumnType("text")
                        .HasColumnName("sec_four_content");

                    b.Property<string>("SecFourTitle")
                        .HasColumnType("text")
                        .HasColumnName("sec_four_title");

                    b.Property<string>("SecOneContent")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sec_one_content");

                    b.Property<string>("SecOneTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sec_one_title");

                    b.Property<string>("SecThreeContent")
                        .HasColumnType("text")
                        .HasColumnName("sec_three_content");

                    b.Property<string>("SecThreeTitle")
                        .HasColumnType("text")
                        .HasColumnName("sec_three_title");

                    b.Property<string>("SecTwoContent")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sec_two_content");

                    b.Property<string>("SecTwoTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sec_two_title");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("topic");

                    b.HasKey("Id")
                        .HasName("pk_blog_posts");

                    b.ToTable("blog_posts", (string)null);
                });

            modelBuilder.Entity("bradenasmith.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BlogPostId")
                        .HasColumnType("integer")
                        .HasColumnName("blog_post_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.HasKey("Id")
                        .HasName("pk_comments");

                    b.HasIndex("BlogPostId")
                        .HasDatabaseName("ix_comments_blog_post_id");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("bradenasmith.Models.Comment", b =>
                {
                    b.HasOne("bradenasmith.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_blog_posts_blog_post_id");

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("bradenasmith.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
