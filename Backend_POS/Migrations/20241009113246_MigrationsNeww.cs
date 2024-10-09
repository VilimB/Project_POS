using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsNeww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c63a16a-57f8-469a-9688-55ea62fe78ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4d8e823-5dc4-40e8-a7f2-4d3060e33236");

            migrationBuilder.AddColumn<string>(
                name: "XmlRacun",
                table: "ZaglavljeRacuna",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a721193f-cbdc-4c76-8348-4a4e03c6f134", null, "User", "USER" },
                    { "b86f719b-cb7c-45b3-badc-863800828881", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a721193f-cbdc-4c76-8348-4a4e03c6f134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b86f719b-cb7c-45b3-badc-863800828881");

            migrationBuilder.DropColumn(
                name: "XmlRacun",
                table: "ZaglavljeRacuna");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c63a16a-57f8-469a-9688-55ea62fe78ad", null, "User", "USER" },
                    { "f4d8e823-5dc4-40e8-a7f2-4d3060e33236", null, "Admin", "ADMIN" }
                });
        }
    }
}
