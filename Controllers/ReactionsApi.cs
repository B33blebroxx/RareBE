namespace RareBE.Controllers
{
    public class ReactionsApi
    {
        public static void Map(WebApplication app)
        {
            // View a Posts Reactions
            app.MapGet("/post/{postId}/reactions", (RareBEDbContext db, int postId) =>
            {
                var post = db.Posts.Where(p => p.Id == postId).FirstOrDefault();
                var reactions = post.Reactions.ToList();
                if (post == null) 
                {
                    return Results.NotFound();
                }
                if (reactions == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(reactions);
            });

            // Add a Reaction to a Post
            app.MapPost("/post/{postId}/reactions", (RareBEDbContext db) =>
            {

            });
        }
    }
}
