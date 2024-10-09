using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48bf9b35-31f0-42d3-8e1c-cbb501b430b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaad61e3-d922-4e8d-ba28-75283ed75091");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e01f917-85c7-4cf9-be06-4e25ee5b2979", null, "Admin", "ADMIN" },
                    { "fe06dd77-adca-46d2-a51a-94f096ccc90b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e01f917-85c7-4cf9-be06-4e25ee5b2979");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe06dd77-adca-46d2-a51a-94f096ccc90b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48bf9b35-31f0-42d3-8e1c-cbb501b430b8", null, "Admin", "ADMIN" },
                    { "aaad61e3-d922-4e8d-ba28-75283ed75091", null, "User", "USER" }
                });
        }
    }
}
