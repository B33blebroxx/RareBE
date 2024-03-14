using Microsoft.EntityFrameworkCore;
using RareBE.DTOs;
using RareBE.Models;

namespace RareBE.Controllers
{
    public class ReactionsApi
    {
        public static void Map(WebApplication app)
        {
            // View a Posts Reactions
            app.MapGet("/post/{postId}/reactions", (RareBEDbContext db, int postId) =>
            {
                var post = db.Posts.SingleOrDefault(p => p.Id == postId);
                

                if (post == null) 
                {
                    return Results.NotFound();
                }
                return Results.Ok(post);
            });

            // Add a Reaction to a Post
            app.MapPost("/post/add-reaction", (RareBEDbContext db, ReactionDto dto) =>
            {
                var currentReaction = db.Reactions.SingleOrDefault(r => r.Id == dto.ReactionId);
                var post = db.Posts.Include(p => p.Reactions).SingleOrDefault(p => p.Id == dto.PostId);

                if (currentReaction == null || post == null)
                {
                    return Results.NotFound();
                }
                post.Reactions.Add(currentReaction);
                db.SaveChanges();
                return Results.Ok();
            });
        }
    }
}
