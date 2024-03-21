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
    [Migration("20240320235528_UserPhotoUpdate")]
    partial class UserPhotoUpdate
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

                    b.Property<int?>("RareUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Approved = true,
                            Content = "Dive deep into the less known features of iOS that can enhance your daily productivity. From back-tap shortcuts to the magic of custom widgets, learn how to make the most of your iPhone.",
                            ImageUrl = "https://miro.medium.com/v2/resize:fit:2912/1*Cv59R-kinaZ9JZwxb0w4hw.png",
                            PublicationDate = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RareUserId = 3,
                            Title = "10 Hidden Features of iOS That Will Boost Your Productivity"
                        },
                        new
                        {
                            Id = 2,
                            Approved = true,
                            Content = "Explore how Apple's M1 chip is revolutionizing the computing world, offering unmatched performance and efficiency. See how it compares to traditional processors in real-world tasks.",
                            ImageUrl = "https://www.shutterstock.com/image-photo/viersen-germany-may-8-2021-600nw-1974447050.jpg",
                            PublicationDate = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RareUserId = 1,
                            Title = "Why the M1 Chip Redefines Computing"
                        },
                        new
                        {
                            Id = 3,
                            Approved = true,
                            Content = "Trace the journey of the Apple Watch and how it's become an indispensable tool for health, communication, and productivity. Discover the latest features that make it more than just a timepiece.",
                            ImageUrl = "https://media.istockphoto.com/id/1314052259/photo/woman-using-smart-watch-and-smart-phone-apple-watch.jpg?s=612x612&w=0&k=20&c=5JcW_Xmw0-RkOD-D7MNHrzRN2g7_m8WM8ZbV2rGoNAc=",
                            PublicationDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RareUserId = 2,
                            Title = "The Evolution of Apple Watch: From Luxury to Necessity"
                        });
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

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "Bright, fragrant, and sweet",
                            CreatedOn = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "Beautifully written",
                            CreatedOn = new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostId = 3
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Content = "Very exciting",
                            CreatedOn = new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PostId = 2
                        });
                });

            modelBuilder.Entity("RareBE.Models.PostReaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("RareUserId")
                        .HasColumnType("integer");

                    b.Property<int>("ReactionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("RareUserId");

                    b.HasIndex("ReactionId");

                    b.ToTable("PostReactions");
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
                            ProfileImageUrl = "https://i.redd.it/5560va6tsg191.jpg",
                            Uid = "NlqJSegDT4Y2lpb5JEuyrTqQCWu1"
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
                            ProfileImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi6Mtt1B2B-gNpqsHvQWfX0niiWMtSzF-HnWrkiynWjA&s",
                            Uid = "e3PXxd4PTjNS98Uc39OcA6UXhaj2"
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
                            ProfileImageUrl = "https://img.wattpad.com/cover/199323071-288-k263202.jpg",
                            Uid = "6t9aVoqg9dY7Nu5iFGhSJNlOZ7j1"
                        },
                        new
                        {
                            Id = 4,
                            Active = false,
                            Bio = "Web Developer",
                            CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "theGorf@example.com",
                            FirstName = "Jessie",
                            LastName = "Gorfson",
                            ProfileImageUrl = "https://pics.craiyon.com/2023-05-31/220e4c73f6674d46a84840ebde9f9bc8.webp",
                            Uid = "j1QamJg48ihtDd6LcIaXE83KOcF2"
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://p1.hiclipart.com/preview/516/463/730/facebook-reactions-1-png-clipart-thumbnail.jpg",
                            Label = "Like"
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://p7.hiclipart.com/preview/569/541/154/social-media-facebook-love-emoji-facebook-reaction.jpg",
                            Label = "Love"
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d5f41aae-b015-401d-90db-b4fc1ca02719/dbposff-ea25cf15-0729-409e-b815-2d22adfd9551.gif/v1/fill/w_500,h_500/facebook_haha_reaction_by_metallicsedan_dbposff-fullview.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTAwIiwicGF0aCI6IlwvZlwvZDVmNDFhYWUtYjAxNS00MDFkLTkwZGItYjRmYzFjYTAyNzE5XC9kYnBvc2ZmLWVhMjVjZjE1LTA3MjktNDA5ZS1iODE1LTJkMjJhZGZkOTU1MS5naWYiLCJ3aWR0aCI6Ijw9NTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.AGN85B-bQ8Lbuuh09A9qzSPyreHvdgV03nh-QNQcRfk",
                            Label = "Laugh"
                        });
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

            modelBuilder.Entity("RareBE.Models.Comment", b =>
                {
                    b.HasOne("Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RareBE.Models.PostReaction", b =>
                {
                    b.HasOne("Post", "Post")
                        .WithMany("PostReactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RareBE.Models.RareUser", "RareUser")
                        .WithMany()
                        .HasForeignKey("RareUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RareBE.Models.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("RareUser");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostReactions");
                });
#pragma warning restore 612, 618
        }
    }
}
