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
                        ImageUrl = group.FirstOrDefault().Reaction.Image  // Select the first reaction's image
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
                var postReactionsQuery = db.PostReactions.Where(pr => pr.PostId == postId);

                var reactionCounts = postReactionsQuery
                    .GroupBy(pr => new { pr.ReactionId, pr.Reaction.Image })
                    .Select(group => new
                    {
                        ReactionId = group.Key.ReactionId,
                        Label = group.First().Reaction.Label,
                        Image = group.Key.Image,
                        Count = group.Count()
                    })
                    .ToList();

                var totalReactions = postReactionsQuery.Count();

                var result = new
                {
                    TotalReactions = totalReactions,
                    ReactionCounts = reactionCounts
                };

                return Results.Ok(result);
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
