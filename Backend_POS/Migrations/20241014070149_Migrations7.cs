using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migrations7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "90744163-df3e-4dc0-a419-2575d075114c", null, "User", "USER" },
                    { "9da1e5c9-b0e7-4ac6-bf49-4111dfea6ef4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90744163-df3e-4dc0-a419-2575d075114c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da1e5c9-b0e7-4ac6-bf49-4111dfea6ef4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78a3a140-7fac-419f-b04d-8bd3976cc05a", null, "Admin", "ADMIN" },
                    { "dab07212-f570-4150-9b93-3d4eec7477c3", null, "User", "USER" }
                });
        }
    }
}
