using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_POS.Migrations
{
    public partial class NewMi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure no NULL values exist in the Datum column
            migrationBuilder.Sql("UPDATE `ZaglavljeRacuna` SET `Datum` = '0001-01-01 00:00:00' WHERE `Datum` IS NULL;");

            // Alter the Datum column to be non-nullable with a default value
            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "ZaglavljeRacuna",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            // Seed new roles
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77e5ee24-b1d3-4e4d-8875-27783071d0fc", null, "Admin", "ADMIN" },
                    { "e1e13ca9-0c20-4fc9-b53d-1fcd4b82bbbe", null, "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the alterations made in the Up method
            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "ZaglavljeRacuna",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            // Remove newly added roles
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e5ee24-b1d3-4e4d-8875-27783071d0fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e13ca9-0c20-4fc9-b53d-1fcd4b82bbbe");
        }
    }
}
