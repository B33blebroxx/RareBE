using RareBE.Models;

namespace RareBE.Controllers
{
    public class SubscriptionsApi
    {
        public static void Map(WebApplication app)
        {
            // GET subscriptions - for testing purposes only, delete once testing completed
            app.MapGet("/subscriptions", (RareBEDbContext db) =>
            {
                var allSubs = db.Subscriptions.ToList();
                if (allSubs == null) 
                {
                    return Results.NotFound("No Subscriptions");
                }
                return Results.Ok(allSubs);
            });

            // Subscribe to a User
            app.MapPost("/subscriptions/new", (RareBEDbContext db, Subscription newSub) =>
            {
                db.Subscriptions.Add(newSub);
                db.SaveChanges();
                return Results.Created($"/subscriptions/{newSub.Id}", newSub);
            });

            // Unsubscribe from a User
            app.MapDelete("/subscriptions/{subId}", (RareBEDbContext db, int subId) =>
            {
                var subToDelete = db.Subscriptions.Where(s => s.Id == subId).FirstOrDefault();
                if (subToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Subscriptions.Remove(subToDelete);
                db.SaveChanges();
                return Results.Ok("Success!"); 
            });
            
            // GET Subscriber Count
            app.MapGet("/user/{id}/subscribers", (RareBEDbContext db, int id) =>
            {
                var subs = db.Subscriptions.Where(s => s.AuthorId == id).Count();
                return Results.Ok(subs);
            });
        }
    }
}
