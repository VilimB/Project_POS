using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20a990ee-fe67-4ee9-89dd-56deb24b748b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1061c68-5ba6-4ce4-a125-6a1e16decd51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b482ea5-7e86-457f-bb2b-466c996fb90c", null, "Admin", "ADMIN" },
                    { "e22320bf-7487-4803-967d-926f6659c492", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b482ea5-7e86-457f-bb2b-466c996fb90c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22320bf-7487-4803-967d-926f6659c492");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20a990ee-fe67-4ee9-89dd-56deb24b748b", null, "Admin", "ADMIN" },
                    { "a1061c68-5ba6-4ce4-a125-6a1e16decd51", null, "User", "USER" }
                });
        }
    }
}
