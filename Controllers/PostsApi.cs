using RareBE.Models;
using RareBE.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace RareBE.Controllers
{
    public class PostsApi
    {
        public static void Map(WebApplication app)
        {
            //get all posts
            app.MapGet("/posts", (RareBEDbContext db) =>
            {
                var posts = db.Posts
                    .Where(p => p.Approved && p.PublicationDate <= DateTime.Now)
                    .OrderByDescending(p => p.PublicationDate)
                    .Select(p => new {
                        p.Id,
                        p.Title,
                        p.PublicationDate,
                        AuthorDisplayName = db.RareUsers
                        .Where(u => u.Id == p.RareUserId).Select(u => u.FirstName + " " + u.LastName).FirstOrDefault(),
                        p.ImageUrl,
                        p.Content
                    })
                    .ToList();

                return Results.Ok(posts);
            });

            //get single post
            app.MapGet("/posts/{id}", (RareBEDbContext db, int id) =>
            {
                var post = db.Posts
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.ImageUrl,
                    PublicationDate = p.PublicationDate.ToString("MM/dd/yyyy"),
                    Author = db.RareUsers.Where(u => u.Id == p.RareUserId)
                  .Select(u => u.FirstName + " " + u.LastName).FirstOrDefault()
                })
                 .FirstOrDefault();

                if (post == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(post);
            });

            //create post
            app.MapPost("/posts", (RareBEDbContext db, Post newPost) =>
            {
                db.Posts.Add(newPost);
                db.SaveChanges();

                return Results.Created($"/posts/{newPost.Id}", newPost);
                });

             //update post
                app.MapPut("/posts/{id}", (RareBEDbContext db, PostDTO postDto, int id) =>
            {
                var postToUpdate = db.Posts.Find(id);
                if (postToUpdate == null)
                {
                    return Results.NotFound();
                }

                postToUpdate.Title = postDto.Title;
                postToUpdate.Content = postDto.Content;
                postToUpdate.ImageUrl = postDto.ImageUrl;

                db.SaveChanges();
                return Results.Ok(postToUpdate);
            });

            //delete post
            app.MapDelete("/posts/{id}", (RareBEDbContext db, int id) =>
            {
                var postToDelete = db.Posts.Find(id);
                if (postToDelete == null)
                {
                    return Results.NotFound();
                }

                db.Posts.Remove(postToDelete);
                db.SaveChanges();

                return Results.Ok(postToDelete);
            });

            //get a user's posts
            app.MapGet("/users/{userId}/posts", (RareBEDbContext db, int userId) =>
            {
                var posts = db.Posts
                .Where(p => p.RareUserId == userId && p.Approved && p.PublicationDate <= DateTime.UtcNow)
                .OrderByDescending(p => p.PublicationDate)
                .ToList();

                return Results.Ok(posts);
            });

            //get subscribed posts
            app.MapGet("/posts/subscribed", (RareBEDbContext db, int currentUserId) =>
            {
                var subscribedAuthorIds = db.Subscriptions
                 .Where(sub => sub.FollowerId == currentUserId && (sub.EndedOn == null || sub.EndedOn > DateTime.Now))
                  .Select(sub => sub.AuthorId)
                  .Distinct()
                  .ToList();

                var posts = db.Posts
                  .Where(post => subscribedAuthorIds.Contains(post.RareUserId.Value) && post.Approved && post.PublicationDate <= DateTime.Now)
                  .OrderByDescending(post => post.PublicationDate)
                  .Select(post => new {
                      post.Id,
                      post.Title,
                      post.PublicationDate,
                      AuthorId = post.RareUserId,
                      post.ImageUrl,
                      post.Content
                  })
                     .ToList();

                return Results.Ok(posts);
            });

        }
    }
}

