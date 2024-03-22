using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class MaggieFinalFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostReactions",
                columns: new[] { "Id", "PostId", "RareUserId", "ReactionId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 2, 1, 3 },
                    { 4, 3, 2, 1 },
                    { 5, 3, 2, 2 },
                    { 6, 3, 2, 3 },
                    { 7, 1, 3, 1 },
                    { 8, 1, 3, 2 },
                    { 9, 1, 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://www.clker.com/cliparts/k/K/q/9/P/m/blue-thumbs-up-md.png");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://www.clker.com/cliparts/4/1/4/8/1194984842227965453heart_highlight_jon_phil_01.svg.med.png");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://www.clker.com/cliparts/9/3/0/4/1194986482324150491smiley_nicolas_01.svg.med.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PostReactions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://p1.hiclipart.com/preview/516/463/730/facebook-reactions-1-png-clipart-thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://p7.hiclipart.com/preview/569/541/154/social-media-facebook-love-emoji-facebook-reaction.jpg");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d5f41aae-b015-401d-90db-b4fc1ca02719/dbposff-ea25cf15-0729-409e-b815-2d22adfd9551.gif/v1/fill/w_500,h_500/facebook_haha_reaction_by_metallicsedan_dbposff-fullview.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTAwIiwicGF0aCI6IlwvZlwvZDVmNDFhYWUtYjAxNS00MDFkLTkwZGItYjRmYzFjYTAyNzE5XC9kYnBvc2ZmLWVhMjVjZjE1LTA3MjktNDA5ZS1iODE1LTJkMjJhZGZkOTU1MS5naWYiLCJ3aWR0aCI6Ijw9NTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.AGN85B-bQ8Lbuuh09A9qzSPyreHvdgV03nh-QNQcRfk");
        }
    }
}
