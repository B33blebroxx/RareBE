using RareBE.Models;
using Microsoft.EntityFrameworkCore;

namespace RareBE.Controllers
{
    public class RareUsersApi
    {
        public static void Map(WebApplication app)
        {

            //Checkuser
            app.MapGet("/checkuser/{uid}", (RareBEDbContext db, string uid) =>
            {
                var user = db.RareUsers.Where(ru => ru.Uid == uid).ToList();

                if (user == null)
                {
                    return Results.NotFound("User not registered");
                }

                return Results.Ok(user);
            });

            //Create User
            app.MapPost("/users/register", (RareBEDbContext db, RareUser newUser) =>
            {
                try
                {
                    db.RareUsers.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Couldn't create new user, please try again!");
                }
            });

            //Edit User Profile
            app.MapPut("/users/{id}", (RareBEDbContext db, int id, RareUser user) =>
            {
                var userBeingUpdated = db.RareUsers.Find(id);
                
                if (userBeingUpdated == null)
                {
                    return Results.NotFound("No user found with that ID");
                }

                userBeingUpdated.Id = user.Id;
                userBeingUpdated.FirstName = user.FirstName;
                userBeingUpdated.LastName = user.LastName;
                userBeingUpdated.Bio = user.Bio;
                userBeingUpdated.ProfileImageUrl = user.ProfileImageUrl;
                userBeingUpdated.Email = user.Email;

                db.SaveChanges();
                return Results.Ok("Rare User has been updated!");
            });

            //View Single Profile Details
            app.MapGet("/users/{id}", (RareBEDbContext db, int id) =>
            {
                var user = db.RareUsers.Find(id);

            if (user == null)
                {
                    return Results.NotFound("No user found with that ID");
                }

                string formattedCreationDate = user.CreatedOn.ToString("MM/dd/yyyy");

                var userDetails = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.ProfileImageUrl,
                    user.Bio,
                    user.Email,
                    CreatedOn = formattedCreationDate,
                    user.Uid
                };

                return Results.Ok(userDetails);
            });

            //Get all users
            app.MapGet("/users", (RareBEDbContext db) =>
            {
                var users = db.RareUsers
                            .Select(ru => new
                            {
                                ru.Id,
                                ru.FirstName,
                                ru.LastName,
                                ru.ProfileImageUrl
                            });

                return Results.Ok(users);
            });
        }
    }
}
