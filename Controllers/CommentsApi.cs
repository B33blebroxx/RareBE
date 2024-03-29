﻿using RareBE.Models;
using RareBE.DTOs;
using Microsoft.EntityFrameworkCore;
namespace RareBE.Controllers
{
    public class CommentsApi
    {
        public static void Map(WebApplication app)
        {
            //create a comment
            app.MapPost("/comments/new", (RareBEDbContext db, Comment comment) =>
            {
                var newComment = new Comment // Instantiate the Comment object
                {
                    Id = comment.Id,
                    AuthorId = comment.AuthorId,
                    PostId = comment.PostId,
                    Content = comment.Content, // Assign the Content property
                    CreatedOn = DateTime.Now // Assign the current datetime
                }; // Close the instantiation

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
            }); // Close the lambda function


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
                db.SaveChanges();

                return Results.Ok(commentToDelete);
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
                return Results.Ok(commentToUpdate);
            });


            //get post's comments with RareUser's first and last name
            app.MapGet("/posts/{postId}/comments", (RareBEDbContext db, int postId) =>
            {
                var postComments = db.Posts
                    .Include(p => p.Comments)
                    .Include(p => p.PostReactions)
                    .ThenInclude(pr => pr.Reaction)
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
                                c.AuthorId,
                                AuthorName = db.RareUsers
                                    .Where(u => u.Id == c.AuthorId)
                                    .Select(u => u.FirstName + " " + u.LastName)
                                    .FirstOrDefault(), // Get author's first and last name
                                c.Content,
                                CreatedOn = c.CreatedOn.ToString("MM/dd/yyyy"), // Convert CreatedOn to string
                            }),
                        PostReactions = p.PostReactions.Select(pr => new
                        {
                            pr.Id,
                            pr.Reaction.Label,
                            pr.Reaction.Image,
                            pr.PostId
                        }).ToList(),
                        ReactionCounts = p.PostReactions
                .GroupBy(pr => pr.Reaction.Label)
                .Select(group => new
                {
                    ReactionLabel = group.Key,
                    Count = group.Count()
                }).ToList()
                    })
                    .FirstOrDefault();

                return Results.Ok(postComments);
            });



        }
    }
}
