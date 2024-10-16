using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aeef66c-8d29-4076-80f8-2a1b83d380b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c65c75-96fa-41c8-9b9b-3088fc98c9de");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01671698-dd98-4274-8174-14d5b4958a3b", null, "User", "USER" },
                    { "dad6919e-3ada-4e1f-8cda-c79b0d4c53b9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01671698-dd98-4274-8174-14d5b4958a3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad6919e-3ada-4e1f-8cda-c79b0d4c53b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8aeef66c-8d29-4076-80f8-2a1b83d380b2", null, "Admin", "ADMIN" },
                    { "e6c65c75-96fa-41c8-9b9b-3088fc98c9de", null, "User", "USER" }
                });
        }
    }
}
