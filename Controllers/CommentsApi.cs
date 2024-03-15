using RareBE.Models;
using RareBE.DTOs;
using Microsoft.EntityFrameworkCore;
namespace RareBE.Controllers
{
    public class CommentsApi
    {
        public static void Map(WebApplication app)
        {
            //create a comment
            app.MapPost("/comments", (RareBEDbContext db, Comment newComment) =>
            {
                try
                {
                    db.Comments.Add(newComment);
                    db.SaveChanges();
                    return Results.Created($"api/comments/{newComment.Id}", newComment);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });

            //delete a single comment
            app.MapDelete("/comments/{commentId}", (RareBEDbContext db, int commentId) =>
            {
                var commentToDelete = db.Comments.FirstOrDefault(c => c.Id == commentId);
                if (commentToDelete == null)
                {
                    return Results.NotFound("Comment not found!");
                }

                db.Comments.Remove(commentToDelete);
                return Results.Ok("Comment deleted successfully.");
            });

            //update Comment
            app.MapPut("/comments/{commentId}", (RareBEDbContext db, int commentId, CommentDto comment) =>
{
                Comment commentToUpdate = db.Comments.SingleOrDefault(c => c.Id == commentId);
                if (commentToUpdate == null)
                {
                    return Results.NotFound();
                }
                commentToUpdate.Content = comment.Content;
                commentToUpdate.CreatedOn = DateTime.Now;

                db.SaveChanges();
                return Results.NoContent();
            });


            //get post's comments with RareUser's first and last name
            app.MapGet("/posts/{postId}/comments", (RareBEDbContext db, int postId) =>
            {
                var postComments = db.Posts
                    .Include(p => p.Comments)
                    .Where(p => p.Id == postId) // Filter by postId
                    .Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.PublicationDate,
                        AuthorDisplayName = db.RareUsers
                            .Where(u => u.Id == p.RareUserId)
                            .Select(u => u.FirstName + " " + u.LastName)
                            .FirstOrDefault(), // Construct AuthorDisplayName
                        p.ImageUrl,
                        p.Content,
                        p.Approved,
                        p.Reactions
                    })
                    .FirstOrDefault();

                return Results.Ok(postComments);
            });





        }
    }
}
