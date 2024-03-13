using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class DataFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 2, 21, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4735), 3 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 2, 26, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4742), 1 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 3, 2, 19, 53, 14, 675, DateTimeKind.Local).AddTicks(4744), 2 });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "Image", "Label" },
                values: new object[,]
                {
                    { 1, "https://p1.hiclipart.com/preview/516/463/730/facebook-reactions-1-png-clipart-thumbnail.jpg", "Like" },
                    { 2, "https://p7.hiclipart.com/preview/569/541/154/social-media-facebook-love-emoji-facebook-reaction.jpg", "Love" },
                    { 3, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d5f41aae-b015-401d-90db-b4fc1ca02719/dbposff-ea25cf15-0729-409e-b815-2d22adfd9551.gif/v1/fill/w_500,h_500/facebook_haha_reaction_by_metallicsedan_dbposff-fullview.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTAwIiwicGF0aCI6IlwvZlwvZDVmNDFhYWUtYjAxNS00MDFkLTkwZGItYjRmYzFjYTAyNzE5XC9kYnBvc2ZmLWVhMjVjZjE1LTA3MjktNDA5ZS1iODE1LTJkMjJhZGZkOTU1MS5naWYiLCJ3aWR0aCI6Ijw9NTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.AGN85B-bQ8Lbuuh09A9qzSPyreHvdgV03nh-QNQcRfk", "Laugh" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 2, 21, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8906), null });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 2, 26, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8910), null });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 3, 2, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8912), null });
        }
    }
}
