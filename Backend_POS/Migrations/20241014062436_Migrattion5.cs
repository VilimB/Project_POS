using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migrattion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2085502b-7cb1-4512-9232-9f86f42b7bab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a792fdd8-e499-4d5c-a732-ce1f8be95821");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "511ae359-2a3d-4abc-a183-76eb2df62d88", null, "User", "USER" },
                    { "6f5a95e8-36b1-41bd-9ad4-54738ccf688c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "511ae359-2a3d-4abc-a183-76eb2df62d88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f5a95e8-36b1-41bd-9ad4-54738ccf688c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2085502b-7cb1-4512-9232-9f86f42b7bab", null, "Admin", "ADMIN" },
                    { "a792fdd8-e499-4d5c-a732-ce1f8be95821", null, "User", "USER" }
                });
        }
    }
}
