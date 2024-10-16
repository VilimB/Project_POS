using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "c6f8a0bd-3d75-4e52-9a2b-3d1c647186e4", null, "Admin", "ADMIN" },
                    { "f6aca3ee-2aeb-444e-94bd-d05b93d94d73", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f8a0bd-3d75-4e52-9a2b-3d1c647186e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6aca3ee-2aeb-444e-94bd-d05b93d94d73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9cf5f5b9-1e36-42fd-b8d8-928cb547d2fd", null, "User", "USER" },
                    { "e85a6892-22cd-4dd9-b792-e8c83b240d33", null, "Admin", "ADMIN" }
                });
        }
    }
}
