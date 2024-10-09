using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class New12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e5ee24-b1d3-4e4d-8875-27783071d0fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e13ca9-0c20-4fc9-b53d-1fcd4b82bbbe");

            migrationBuilder.AddColumn<int>(
                name: "Broj",
                table: "StavkeRacuna",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "StavkeRacuna",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48bf9b35-31f0-42d3-8e1c-cbb501b430b8", null, "Admin", "ADMIN" },
                    { "aaad61e3-d922-4e8d-ba28-75283ed75091", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48bf9b35-31f0-42d3-8e1c-cbb501b430b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaad61e3-d922-4e8d-ba28-75283ed75091");

            migrationBuilder.DropColumn(
                name: "Broj",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "StavkeRacuna");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77e5ee24-b1d3-4e4d-8875-27783071d0fc", null, "Admin", "ADMIN" },
                    { "e1e13ca9-0c20-4fc9-b53d-1fcd4b82bbbe", null, "User", "USER" }
                });
        }
    }
}
