using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "78a3a140-7fac-419f-b04d-8bd3976cc05a", null, "Admin", "ADMIN" },
                    { "dab07212-f570-4150-9b93-3d4eec7477c3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78a3a140-7fac-419f-b04d-8bd3976cc05a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dab07212-f570-4150-9b93-3d4eec7477c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "511ae359-2a3d-4abc-a183-76eb2df62d88", null, "User", "USER" },
                    { "6f5a95e8-36b1-41bd-9ad4-54738ccf688c", null, "Admin", "ADMIN" }
                });
        }
    }
}
