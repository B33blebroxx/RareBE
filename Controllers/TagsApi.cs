using RareBE.Models;
using RareBE.DTOs;
using Microsoft.EntityFrameworkCore;
namespace RareBE.Controllers
{
    public class TagsApi
    {
        public static void Map(WebApplication app)
        {
            //create a tag
            app.MapPost("/tags", (RareBEDbContext db, Tag newTag) =>
            {
                try
                {
                    db.Tags.Add(newTag);
                    db.SaveChanges();
                    return Results.Created($"/tags/{newTag.Id}", newTag);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });

            //delete a single tag
            app.MapDelete("/tags/{tagId}", (RareBEDbContext db, int tagId) =>
            {
                var tagToDelete = db.Tags.FirstOrDefault(t => t.Id == tagId);
                if (tagToDelete == null)
                {
                    return Results.NotFound("Comment not found!");
                }

                db.Tags.Remove(tagToDelete);
                return Results.Ok("Comment deleted successfully.");
            });

            app.MapPost("/post/addTag", (RareBEDbContext db, PostTagsDto postTag) =>
            {
                var singlePostToUpdate = db.Posts
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == postTag.PostId);
                var tagToAdd = db.Tags.FirstOrDefault(p => p.Id == postTag.TagId);

                try
                {
                    singlePostToUpdate.Tags.Add(tagToAdd);
                    db.SaveChanges();
                    return Results.NoContent();

                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });
        }
    }
}
