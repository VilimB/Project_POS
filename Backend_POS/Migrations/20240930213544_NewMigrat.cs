using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aada8ba9-f848-4d87-8e05-369418ff4fce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5f1840c-4c8d-497c-9bc1-0e6a722877e8");

            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "StavkeRacuna",
                newName: "NazivProizvod");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c63a16a-57f8-469a-9688-55ea62fe78ad", null, "User", "USER" },
                    { "f4d8e823-5dc4-40e8-a7f2-4d3060e33236", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c63a16a-57f8-469a-9688-55ea62fe78ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4d8e823-5dc4-40e8-a7f2-4d3060e33236");

            migrationBuilder.RenameColumn(
                name: "NazivProizvod",
                table: "StavkeRacuna",
                newName: "Naziv");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aada8ba9-f848-4d87-8e05-369418ff4fce", null, "User", "USER" },
                    { "b5f1840c-4c8d-497c-9bc1-0e6a722877e8", null, "Admin", "ADMIN" }
                });
        }
    }
}
