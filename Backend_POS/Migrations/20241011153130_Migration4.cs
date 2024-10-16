using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b482ea5-7e86-457f-bb2b-466c996fb90c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22320bf-7487-4803-967d-926f6659c492");

            migrationBuilder.DropColumn(
                name: "Broj",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "NazivProizvod",
                table: "StavkeRacuna");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2085502b-7cb1-4512-9232-9f86f42b7bab", null, "Admin", "ADMIN" },
                    { "a792fdd8-e499-4d5c-a732-ce1f8be95821", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2085502b-7cb1-4512-9232-9f86f42b7bab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a792fdd8-e499-4d5c-a732-ce1f8be95821");

            migrationBuilder.AddColumn<int>(
                name: "Broj",
                table: "StavkeRacuna",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NazivProizvod",
                table: "StavkeRacuna",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b482ea5-7e86-457f-bb2b-466c996fb90c", null, "Admin", "ADMIN" },
                    { "e22320bf-7487-4803-967d-926f6659c492", null, "User", "USER" }
                });
        }
    }
}
