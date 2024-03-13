using RareBE.Models;
using Microsoft.EntityFrameworkCore;

namespace RareBE.Controllers
{
    public class RareUsers
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
        }
    }
}
