using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34259c50-eca7-49da-b92e-8f2cd42ce817");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56976fb6-5307-4124-9c2f-cd113282ecf3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20a990ee-fe67-4ee9-89dd-56deb24b748b", null, "Admin", "ADMIN" },
                    { "a1061c68-5ba6-4ce4-a125-6a1e16decd51", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "34259c50-eca7-49da-b92e-8f2cd42ce817", null, "User", "USER" },
                    { "56976fb6-5307-4124-9c2f-cd113282ecf3", null, "Admin", "ADMIN" }
                });
        }
    }
}
