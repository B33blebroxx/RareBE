using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class ReactionsFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Reactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Reactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
