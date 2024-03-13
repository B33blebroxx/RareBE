using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using RareBE.Models;

public class RareBEDbContext : DbContext
{
    public DbSet<RareUser> RareUsers { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Reaction> Reactions { get; set; }


    public RareBEDbContext(DbContextOptions<RareBEDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>().HasData(new Comment[]
     {
        new Comment { Id = 1, AuthorId = 1, PostId = 1, Content = "Bright, fragrant, and sweet", CreatedOn = DateTime.Now },
        new Comment { Id = 2, AuthorId = 2, PostId = 3, Content = "Beautifully written", CreatedOn = DateTime.Now },
        new Comment { Id = 3, AuthorId = 3, PostId = 2, Content = "Very exciting", CreatedOn = DateTime.Now },
        new Comment { Id = 4, AuthorId = 4, PostId = 4, Content = "So glad I read this!", CreatedOn = DateTime.Now },
     });

        modelBuilder.Entity<Post>().HasData(new Post[]
     {
        new Post {
            Id = 1,
            RareUserId = 3,
            Title = "10 Hidden Features of iOS That Will Boost Your Productivity",
            PublicationDate = DateTime.Now.AddDays(-20),
            ImageUrl = "https://miro.medium.com/v2/resize:fit:2912/1*Cv59R-kinaZ9JZwxb0w4hw.png",
            Content = "Dive deep into the less known features of iOS that can enhance your daily productivity. From back-tap shortcuts to the magic of custom widgets, learn how to make the most of your iPhone.",
            Approved = true
        },
        new Post {
            Id = 2,
            RareUserId = 1,
            Title = "Why the M1 Chip Redefines Computing",
            PublicationDate = DateTime.Now.AddDays(-15),
            ImageUrl = "https://www.shutterstock.com/image-photo/viersen-germany-may-8-2021-600nw-1974447050.jpg",
            Content = "Explore how Apple's M1 chip is revolutionizing the computing world, offering unmatched performance and efficiency. See how it compares to traditional processors in real-world tasks.",
            Approved = true
        },
        new Post {
            Id = 3,
            RareUserId = 2,
            Title = "The Evolution of Apple Watch: From Luxury to Necessity",
            PublicationDate = DateTime.Now.AddDays(-10),
            ImageUrl = "https://media.istockphoto.com/id/1314052259/photo/woman-using-smart-watch-and-smart-phone-apple-watch.jpg?s=612x612&w=0&k=20&c=5JcW_Xmw0-RkOD-D7MNHrzRN2g7_m8WM8ZbV2rGoNAc=",
            Content = "Trace the journey of the Apple Watch and how it's become an indispensable tool for health, communication, and productivity. Discover the latest features that make it more than just a timepiece.",
            Approved = true
        },
     });

        modelBuilder.Entity<Subscription>().HasData(new Subscription[]
     {
        new Subscription { Id = 1, FollowerId = 1, AuthorId = 2, CreatedOn = new DateTime(2024, 1, 10)},
        new Subscription { Id = 2, FollowerId = 2, AuthorId = 3, CreatedOn = new DateTime(2024, 1, 11)},
        new Subscription { Id = 3, FollowerId = 1, AuthorId = 3, CreatedOn = new DateTime(2024, 1, 15)},
     });


        modelBuilder.Entity<RareUser>().HasData(new RareUser[]
        {
            new RareUser
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Bio = "Software Engineer",
                ProfileImageUrl = "https://example.com/profile1.jpg",
                Email = "john.doe@example.com",
                CreatedOn = new DateTime (2024,03,01),
                Active = true,
                Uid = null
            },

            new RareUser
            {
                Id = 2,
                FirstName = "Alice",
                LastName = "Smith",
                Bio = "Data Scientist",
                ProfileImageUrl = "https://example.com/profile2.jpg",
                Email = "alice.smith@example.com",
                CreatedOn = new DateTime (2024,02,12),
                Active = true,
                Uid = null
            },

            new RareUser
            {
                Id = 3,
                FirstName = "Emily",
                LastName = "Jones",
                Bio = "Graphic Designer",
                ProfileImageUrl = "https://example.com/profile3.jpg",
                Email = "emily.jones@example.com",
                CreatedOn = new DateTime (2023,12,12),
                Active = false,
                Uid = null
        }
    });

    }

}
