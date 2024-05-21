using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class NewMi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37694ec-cf09-4230-8c86-7cbe30a5cec2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c66dba3a-a458-4424-ba39-0cb333d106aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28c71e49-ab07-4177-ba03-6d5804302b2d", null, "Admin", "ADMIN" },
                    { "ede13e6f-2aac-4b35-be46-e5bb36e40c36", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28c71e49-ab07-4177-ba03-6d5804302b2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede13e6f-2aac-4b35-be46-e5bb36e40c36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a37694ec-cf09-4230-8c86-7cbe30a5cec2", null, "Admin", "ADMIN" },
                    { "c66dba3a-a458-4424-ba39-0cb333d106aa", null, "User", "USER" }
                });
        }
    }
}
