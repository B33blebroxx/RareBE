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
                var postReactions = db.PostReactions.Where(x => x.PostId == postId).ToList();

                ReactionDto dto = new()
                {
                    LikeReactions = postReactions.Where(x => x.ReactionId == 1).Count(),
                    LoveReactions = postReactions.Where(x => x.ReactionId == 2).Count(),
                    LaughReactions = postReactions.Where(x => x.ReactionId == 3).Count()
                };
                
                if (postReactions == null) 
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            });

            // Add a Reaction to a Post
            app.MapPost("/post/add-reaction", (RareBEDbContext db, PostReaction newPostReaction) =>
            {
                db.PostReactions.Add(newPostReaction);
                var currentReaction = db.Reactions.SingleOrDefault(r => r.Id == newPostReaction.ReactionId);
                var post = db.Posts.Include(p => p.Reactions).SingleOrDefault(p => p.Id == newPostReaction.PostId);

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
