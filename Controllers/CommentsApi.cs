using RareBE.Models;
using RareBE.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
namespace RareBE.Controllers
{
    public class CommentsApi
    {
        public static void Map(WebApplication app)
        {
            //create a comment
            app.MapPost("api/comments", (RareBEDbContext db, Comment newComment) =>
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
            app.MapDelete("api/comments/{commentId}", (RareBEDbContext db, int commentId) =>
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
            app.MapPut("api/comments/{commentId}", (RareBEDbContext db, int commentId, CommentDto comment) =>
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

            //get post's comments
            app.MapGet("api/posts/{postId}/comments", (RareBEDbContext db, int postId) =>
            {
                var postComments = db.Posts
                .Include(p => p.Comments)
               .FirstOrDefault(p => p.Id == postId);
                return Results.Ok(postComments);
            });


        }
    }
}
