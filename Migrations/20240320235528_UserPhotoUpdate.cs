using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class UserPhotoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileImageUrl",
                value: "https://i.redd.it/5560va6tsg191.jpg");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfileImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi6Mtt1B2B-gNpqsHvQWfX0niiWMtSzF-HnWrkiynWjA&s");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfileImageUrl",
                value: "https://img.wattpad.com/cover/199323071-288-k263202.jpg");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProfileImageUrl",
                value: "https://pics.craiyon.com/2023-05-31/220e4c73f6674d46a84840ebde9f9bc8.webp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileImageUrl",
                value: "https://example.com/profile1.jpg");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfileImageUrl",
                value: "https://example.com/profile2.jpg");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProfileImageUrl",
                value: "https://example.com/profile3.jpg");

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProfileImageUrl",
                value: "https://example.com/profile3.jpg");
        }
    }
}
