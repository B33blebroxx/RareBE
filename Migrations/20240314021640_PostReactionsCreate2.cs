using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class PostReactionsCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactioons",
                table: "PostReactioons");

            migrationBuilder.RenameTable(
                name: "PostReactioons",
                newName: "PostReactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReactions",
                table: "PostReactions");

            migrationBuilder.RenameTable(
                name: "PostReactions",
                newName: "PostReactioons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReactioons",
                table: "PostReactioons",
                column: "Id");
        }
    }
}
