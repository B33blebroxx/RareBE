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
            app.MapGet("/posts/{postId}/reaction-details", (RareBEDbContext db, int postId) =>
            {
                var reactions = db.PostReactions
                    .Include(pr => pr.Reaction)
                    .Where(pr => pr.PostId == postId)
                    .GroupBy(pr => pr.Reaction.Label)
                    .Select(group => new
                    {
                        Label = group.Key,
                        Count = group.Count(),
                        ImageUrl = group.First().Reaction.Image // Assuming all reactions of the same type have the same image
                    })
                    .ToList();

                return Results.Ok(reactions);
            });
            //update Reaction
            app.MapPut("/reactions/{reactionId}", (RareBEDbContext db, int reactionId, Reaction reaction) =>
            {
                Reaction reactionToUpdate = db.Reactions.SingleOrDefault(r => r.Id == reactionId);
                if (reactionToUpdate == null)
                {
                    return Results.NotFound();
                }
                reactionToUpdate.Id = reaction.Id;
                reactionToUpdate.Label = reaction.Label;
                reactionToUpdate.Image = reaction.Image;


                db.SaveChanges();
                return Results.Ok(reactionToUpdate);
            });

            // View Total of Each Reaction on a Post
            app.MapGet("/post/{postId}/reactions", (RareBEDbContext db, int postId) =>
            {
                var reactionCounts = db.PostReactions
                    .Where(pr => pr.PostId == postId)
                    .GroupBy(pr => pr.ReactionId)
                    .Select(group => new
                    {
                        ReactionId = group.Key,
                        Count = group.Count()
                    })
                    .ToList();

                var totals = new PostReactionsTotalsDto
                {
                    Likes = reactionCounts.FirstOrDefault(rc => rc.ReactionId == 1)?.Count ?? 0,
                    Loves = reactionCounts.FirstOrDefault(rc => rc.ReactionId == 2)?.Count ?? 0,
                    Laughs = reactionCounts.FirstOrDefault(rc => rc.ReactionId == 3)?.Count ?? 0,
                    TotalReactions = reactionCounts.Sum(rc => rc.Count)
                };

                return Results.Ok(totals);
            });


            // Add a Reaction to a Post
            app.MapPost("/post/add-reaction", (RareBEDbContext db, PostReactionDto dto) =>
            {
                // Check if the post and user exist
                if (!db.Posts.Any(p => p.Id == dto.PostId) || !db.RareUsers.Any(u => u.Id == dto.RareUserId))
                {
                    return Results.NotFound();
                }

                // Create a new PostReaction
                PostReaction postReaction = new PostReaction
                {
                    ReactionId = dto.ReactionId,
                    PostId = dto.PostId,
                    RareUserId = dto.RareUserId
                };

                db.PostReactions.Add(postReaction);
                db.SaveChanges();
                return Results.Ok();
            });

        }
    }
}
