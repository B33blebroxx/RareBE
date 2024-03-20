using RareBE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace RareBE.Controllers
{
    public class SearchApi
    {
        public static void Map(WebApplication app)
        {
            //Search posts by Title
            app.MapGet("/posts/search/{query}", (RareBEDbContext db, string query) =>
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return Results.BadRequest("Search query cannot be empty");
                }

                var filteredPosts = db.Posts.Where(p => p.Title.ToLower().Contains(query.ToLower())).ToList();

                if (filteredPosts.Count == 0)
                {
                    return Results.NotFound("No posts found for the given search query.");
                }
                else
                {
                    return Results.Ok(filteredPosts);
                }
            });
        }
    }
}
