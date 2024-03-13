using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RareBE.Migrations
{
    public partial class DataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Uid",
                table: "Posts",
                newName: "RareUserId");

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
                column: "PublicationDate",
                value: new DateTime(2024, 2, 21, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 2, 26, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2024, 3, 2, 19, 39, 29, 165, DateTimeKind.Local).AddTicks(8912));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RareUserId",
                table: "Posts",
                newName: "Uid");

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
                column: "PublicationDate",
                value: new DateTime(2024, 2, 21, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 2, 26, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2024, 3, 2, 19, 25, 44, 885, DateTimeKind.Local).AddTicks(2851));
        }
    }
}
