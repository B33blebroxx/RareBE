using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 12, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 2, 26, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2849), null });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublicationDate", "RareUserId" },
                values: new object[] { new DateTime(2024, 3, 2, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2851), null });
        }
    }
}
