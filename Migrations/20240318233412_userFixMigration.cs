using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class userFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostReaction");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: "NlqJSegDT4Y2lpb5JEuyrTqQCWu1");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: "e3PXxd4PTjNS98Uc39OcA6UXhaj2");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Uid",
                value: "6t9aVoqg9dY7Nu5iFGhSJNlOZ7j1");

            migrationBuilder.InsertData(
                table: "RareUsers",
                columns: new[] { "Id", "Active", "Bio", "CreatedOn", "Email", "FirstName", "LastName", "ProfileImageUrl", "Uid" },
                values: new object[] { 4, false, "Web Developer", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theGorf@example.com", "Jessie", "Gorfson", "https://example.com/profile3.jpg", "j1QamJg48ihtDd6LcIaXE83KOcF2" });

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_RareUserId",
                table: "PostReactions",
                column: "RareUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_ReactionId",
                table: "PostReactions",
                column: "ReactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Posts_PostId",
                table: "PostReactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_RareUsers_RareUserId",
                table: "PostReactions",
                column: "RareUserId",
                principalTable: "RareUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_Reactions_ReactionId",
                table: "PostReactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Posts_PostId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_RareUsers_RareUserId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_Reactions_ReactionId",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_PostReactions_RareUserId",
                table: "PostReactions");

            migrationBuilder.DropIndex(
                name: "IX_PostReactions_ReactionId",
                table: "PostReactions");

            migrationBuilder.DeleteData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "PostReaction",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    ReactionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReaction", x => new { x.PostsId, x.ReactionsId });
                    table.ForeignKey(
                        name: "FK_PostReaction_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReaction_Reactions_ReactionsId",
                        column: x => x.ReactionsId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: null);

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Uid",
                value: null);

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Uid",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_ReactionsId",
                table: "PostReaction",
                column: "ReactionsId");
        }
    }
}
