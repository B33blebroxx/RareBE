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

            //get single comment
            app.MapGet("/comments/{id}", (RareBEDbContext db, int id) =>
            {
                var comment = db.Comments
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.PostId,
                    c.Content,
                    CreatedDate = c.CreatedOn.ToString("MM/dd/yyyy"),
                    c.AuthorId,
                    Author = db.RareUsers.Where(u => u.Id == c.AuthorId)
                  .Select(u => u.FirstName + " " + u.LastName).FirstOrDefault()
                })
                 .FirstOrDefault();

                if (comment == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(comment);
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
                        PublicationDate = p.PublicationDate.ToString("MM/dd/yyyy"),
                        AuthorDisplayName = db.RareUsers
                            .Where(u => u.Id == p.RareUserId)
                            .Select(u => u.FirstName + " " + u.LastName)
                            .FirstOrDefault(), // Construct AuthorDisplayName
                        p.ImageUrl,
                        p.Content,
                        Comments = p.Comments
                            .OrderByDescending(c => c.CreatedOn) // Order comments by CreatedOn descending
                            .Select(c => new
                            {
                                c.Id,
                                AuthorName = db.RareUsers
                                    .Where(u => u.Id == c.AuthorId)
                                    .Select(u => u.FirstName + " " + u.LastName)
                                    .FirstOrDefault(), // Get author's first and last name
                                c.Content,
                                CreatedOn = c.CreatedOn.ToString("MM/dd/yyyy"), // Convert CreatedOn to string
                            })
                    })
                    .FirstOrDefault();

                return Results.Ok(postComments);
            });



        }
    }
}
