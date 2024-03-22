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
    public DbSet<PostReaction> PostReactions { get; set; }


    public RareBEDbContext(DbContextOptions<RareBEDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Comment>().HasData(new Comment[]
     {
        new Comment { Id = 1, AuthorId = 1, PostId = 1, Content = "Bright, fragrant, and sweet", CreatedOn = new DateTime(2024, 1, 10) },
        new Comment { Id = 2, AuthorId = 2, PostId = 3, Content = "Beautifully written", CreatedOn = new DateTime(2024, 5, 12) },
        new Comment { Id = 3, AuthorId = 3, PostId = 2, Content = "Very exciting", CreatedOn = new DateTime(2024, 6, 11) },
     });

        modelBuilder.Entity<PostReaction>().HasData(new PostReaction[]
    {
        new PostReaction { Id = 1, RareUserId = 1, PostId = 2, ReactionId = 1 },
        new PostReaction { Id = 2, RareUserId = 1, PostId = 2, ReactionId = 2 },
        new PostReaction { Id = 3, RareUserId = 1, PostId = 2, ReactionId = 3 },
        new PostReaction { Id = 4, RareUserId = 2, PostId = 3, ReactionId = 1 },
        new PostReaction { Id = 5, RareUserId = 2, PostId = 3, ReactionId = 2 },
        new PostReaction { Id = 6, RareUserId = 2, PostId = 3, ReactionId = 3 },
        new PostReaction { Id = 7, RareUserId = 3, PostId = 1, ReactionId = 1 },
        new PostReaction { Id = 8, RareUserId = 3, PostId = 1, ReactionId = 2 },
        new PostReaction { Id = 9, RareUserId = 3, PostId = 1, ReactionId = 3 },
    });

        modelBuilder.Entity<Post>().HasData(new Post[]
     {
        new Post {
            Id = 1,
            RareUserId = 3,
            Title = "10 Hidden Features of iOS That Will Boost Your Productivity",
            PublicationDate = new DateTime(2024, 2, 4),
            ImageUrl = "https://miro.medium.com/v2/resize:fit:2912/1*Cv59R-kinaZ9JZwxb0w4hw.png",
            Content = "Dive deep into the less known features of iOS that can enhance your daily productivity. From back-tap shortcuts to the magic of custom widgets, learn how to make the most of your iPhone.",
            Approved = true
        },
        new Post {
            Id = 2,
            RareUserId = 1,
            Title = "Why the M1 Chip Redefines Computing",
            PublicationDate = new DateTime(2024, 3, 1),
            ImageUrl = "https://www.shutterstock.com/image-photo/viersen-germany-may-8-2021-600nw-1974447050.jpg",
            Content = "Explore how Apple's M1 chip is revolutionizing the computing world, offering unmatched performance and efficiency. See how it compares to traditional processors in real-world tasks.",
            Approved = true
        },
        new Post {
            Id = 3,
            RareUserId = 2,
            Title = "The Evolution of Apple Watch: From Luxury to Necessity",
            PublicationDate = new DateTime(2024, 1, 10),
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
                ProfileImageUrl = "https://i.redd.it/5560va6tsg191.jpg",
                Email = "john.doe@example.com",
                CreatedOn = new DateTime (2024,03,01),
                Active = true,
                Uid = "NlqJSegDT4Y2lpb5JEuyrTqQCWu1"
            },

            new RareUser
            {
                Id = 2,
                FirstName = "Alice",
                LastName = "Smith",
                Bio = "Data Scientist",
                ProfileImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi6Mtt1B2B-gNpqsHvQWfX0niiWMtSzF-HnWrkiynWjA&s",
                Email = "alice.smith@example.com",
                CreatedOn = new DateTime (2024,02,12),
                Active = true,
                Uid = "e3PXxd4PTjNS98Uc39OcA6UXhaj2"
            },

            new RareUser
            {
                Id = 3,
                FirstName = "Emily",
                LastName = "Jones",
                Bio = "Graphic Designer",
                ProfileImageUrl = "https://img.wattpad.com/cover/199323071-288-k263202.jpg",
                Email = "emily.jones@example.com",
                CreatedOn = new DateTime (2023,12,12),
                Active = false,
                Uid = "6t9aVoqg9dY7Nu5iFGhSJNlOZ7j1"
            },

            new RareUser
            {
                Id = 4,
                FirstName = "Jessie",
                LastName = "Gorfson",
                Bio = "Web Developer",
                ProfileImageUrl = "https://pics.craiyon.com/2023-05-31/220e4c73f6674d46a84840ebde9f9bc8.webp",
                Email = "theGorf@example.com",
                CreatedOn = new DateTime (2024,01,01),
                Active = false,
                Uid = "j1QamJg48ihtDd6LcIaXE83KOcF2"
            }
    });

        modelBuilder.Entity<Reaction>().HasData(new Reaction[]
    {
        new Reaction { Id = 1, Label = "Like", Image = "https://www.clker.com/cliparts/k/K/q/9/P/m/blue-thumbs-up-md.png" },
        new Reaction { Id = 2, Label = "Love", Image ="https://www.clker.com/cliparts/4/1/4/8/1194984842227965453heart_highlight_jon_phil_01.svg.med.png" },
        new Reaction { Id = 3, Label = "Laugh", Image = "https://www.clker.com/cliparts/9/3/0/4/1194986482324150491smiley_nicolas_01.svg.med.png" },
    });

    }

}
