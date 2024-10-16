using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "8aeef66c-8d29-4076-80f8-2a1b83d380b2", null, "Admin", "ADMIN" },
                    { "e6c65c75-96fa-41c8-9b9b-3088fc98c9de", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "c6f8a0bd-3d75-4e52-9a2b-3d1c647186e4", null, "Admin", "ADMIN" },
                    { "f6aca3ee-2aeb-444e-94bd-d05b93d94d73", null, "User", "USER" }
                });
        }
    }
}
