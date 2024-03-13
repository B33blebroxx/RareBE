﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RareBE.Migrations
{
    [DbContext(typeof(RareBEDbContext))]
    [Migration("20240313004843_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Uid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Approved = true,
                            Content = "Dive deep into the less known features of iOS that can enhance your daily productivity. From back-tap shortcuts to the magic of custom widgets, learn how to make the most of your iPhone.",
                            ImageUrl = "https://miro.medium.com/v2/resize:fit:2912/1*Cv59R-kinaZ9JZwxb0w4hw.png",
                            PublicationDate = new DateTime(2024, 2, 21, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3746),
                            Title = "10 Hidden Features of iOS That Will Boost Your Productivity"
                        },
                        new
                        {
                            Id = 2,
                            Approved = true,
                            Content = "Explore how Apple's M1 chip is revolutionizing the computing world, offering unmatched performance and efficiency. See how it compares to traditional processors in real-world tasks.",
                            ImageUrl = "https://www.shutterstock.com/image-photo/viersen-germany-may-8-2021-600nw-1974447050.jpg",
                            PublicationDate = new DateTime(2024, 2, 26, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3754),
                            Title = "Why the M1 Chip Redefines Computing"
                        },
                        new
                        {
                            Id = 3,
                            Approved = true,
                            Content = "Trace the journey of the Apple Watch and how it's become an indispensable tool for health, communication, and productivity. Discover the latest features that make it more than just a timepiece.",
                            ImageUrl = "https://media.istockphoto.com/id/1314052259/photo/woman-using-smart-watch-and-smart-phone-apple-watch.jpg?s=612x612&w=0&k=20&c=5JcW_Xmw0-RkOD-D7MNHrzRN2g7_m8WM8ZbV2rGoNAc=",
                            PublicationDate = new DateTime(2024, 3, 2, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3756),
                            Title = "The Evolution of Apple Watch: From Luxury to Necessity"
                        });
                });

            modelBuilder.Entity("PostReaction", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("ReactionsId")
                        .HasColumnType("integer");

                    b.HasKey("PostsId", "ReactionsId");

                    b.HasIndex("ReactionsId");

                    b.ToTable("PostReaction");
                });

            modelBuilder.Entity("RareBE.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "Bright, fragrant, and sweet",
                            CreatedOn = new DateTime(2024, 3, 12, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3611),
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "Beautifully written",
                            CreatedOn = new DateTime(2024, 3, 12, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3657),
                            PostId = 3
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Content = "Very exciting",
                            CreatedOn = new DateTime(2024, 3, 12, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3659),
                            PostId = 2
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Content = "So glad I read this!",
                            CreatedOn = new DateTime(2024, 3, 12, 19, 48, 43, 237, DateTimeKind.Local).AddTicks(3660),
                            PostId = 4
                        });
                });

            modelBuilder.Entity("RareBE.Models.RareUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RareUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Bio = "Software Engineer",
                            CreatedOn = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            ProfileImageUrl = "https://example.com/profile1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Bio = "Data Scientist",
                            CreatedOn = new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            ProfileImageUrl = "https://example.com/profile2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Active = false,
                            Bio = "Graphic Designer",
                            CreatedOn = new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily.jones@example.com",
                            FirstName = "Emily",
                            LastName = "Jones",
                            ProfileImageUrl = "https://example.com/profile3.jpg"
                        });
                });

            modelBuilder.Entity("RareBE.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("RareBE.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("EndedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FollowerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            CreatedOn = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FollowerId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 3,
                            CreatedOn = new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FollowerId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CreatedOn = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FollowerId = 1
                        });
                });

            modelBuilder.Entity("PostReaction", b =>
                {
                    b.HasOne("Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RareBE.Models.Reaction", null)
                        .WithMany()
                        .HasForeignKey("ReactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}