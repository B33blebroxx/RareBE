using RareBE.Models;
using Microsoft.EntityFrameworkCore;

namespace RareBE.Controllers
{
    public class RareUsersApi
    {
        public static void Map(WebApplication app)
        {

            //Checkuser
            app.MapGet("/checkuser", (RareBEDbContext db, string uid) =>
            {
                var user = db.RareUsers.SingleOrDefault(ru => ru.Uid == uid);

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
                var userBeingUpdated = db.RareUsers.SingleOrDefault(u => u.Id == id);
                
                if (userBeingUpdated == null)
                {
                    return Results.NotFound("No user found with that ID");
                }

                userBeingUpdated.FirstName = user.FirstName;
                userBeingUpdated.LastName = user.LastName;
                userBeingUpdated.Bio = user.Bio;
                userBeingUpdated.ProfileImageUrl = user.ProfileImageUrl;
                userBeingUpdated.Email = user.Email;

                db.SaveChanges();
                return Results.Ok("Rare User has been updated!");
            });
        }
    }
}
