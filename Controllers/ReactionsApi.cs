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
            app.MapGet("/post/{postId}/reactions-details", (RareBEDbContext db, int postId) =>
            {
                var reactions = db.PostReactions
                    .Include(p => p.RareUser)
                    .Where(x => x.PostId == postId)
                    .Select(p => new
                    {   
                        p.RareUser.FirstName,
                        p.RareUser.LastName,
                        p.Reaction.Label
                    }).ToList();
                
                if (reactions == null) 
                {
                    return Results.NotFound();
                }
                return Results.Ok(reactions);
            });

            // View Total of Each Reaction on a Post
            app.MapGet("/post/{postId}/reactions", (RareBEDbContext db, int postId) =>
            {
                var reactions = db.PostReactions.Where(p => p.PostId == postId).ToList();
                PostReactionsTotalsDto totals = new()
                {
                    Likes = reactions.Where(x => x.ReactionId == 1).Count(),
                    Loves = reactions.Where(x => x.ReactionId == 2).Count(),
                    Laughs = reactions.Where(x => x.ReactionId == 3).Count(),
                    TotalReactions = reactions.Count(),
                };

                if (reactions == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(totals);
            });

            // Add a Reaction to a Post
            app.MapPost("/post/add-reaction", (RareBEDbContext db, PostReactionDto dto) =>
            {
                PostReaction postReaction = new()
                {
                    ReactionId = dto.ReactionId,
                    Reaction = db.Reactions.FirstOrDefault(x => x.Id == dto.ReactionId),
                    PostId = dto.PostId,
                    Post = db.Posts.FirstOrDefault(x => x.Id == dto.PostId),
                    RareUserId = dto.RareUserId,
                    RareUser = db.RareUsers.FirstOrDefault(x => x.Id == dto.RareUserId)
                };

                db.PostReactions.Add(postReaction);
                db.SaveChanges();
                return Results.Ok();
            });
        }
    }
}
