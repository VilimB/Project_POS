using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b53666-999c-4cb6-a51e-2f54d523cb20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eedb5755-7acf-4b15-89c6-4970c153070a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9cf5f5b9-1e36-42fd-b8d8-928cb547d2fd", null, "User", "USER" },
                    { "e85a6892-22cd-4dd9-b792-e8c83b240d33", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cf5f5b9-1e36-42fd-b8d8-928cb547d2fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e85a6892-22cd-4dd9-b792-e8c83b240d33");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17b53666-999c-4cb6-a51e-2f54d523cb20", null, "Admin", "ADMIN" },
                    { "eedb5755-7acf-4b15-89c6-4970c153070a", null, "User", "USER" }
                });
        }
    }
}
