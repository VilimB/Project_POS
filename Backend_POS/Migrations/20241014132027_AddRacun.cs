using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class AddRacun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90744163-df3e-4dc0-a419-2575d075114c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da1e5c9-b0e7-4ac6-bf49-4111dfea6ef4");

            migrationBuilder.AddColumn<int>(
                name: "RacunId",
                table: "StavkeRacuna",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrojRacuna = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    KupacId = table.Column<int>(type: "int", nullable: false),
                    XmlRacun = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZaglavljeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racun_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_ZaglavljeRacuna_ZaglavljeId",
                        column: x => x.ZaglavljeId,
                        principalTable: "ZaglavljeRacuna",
                        principalColumn: "ZaglavljeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17b53666-999c-4cb6-a51e-2f54d523cb20", null, "Admin", "ADMIN" },
                    { "eedb5755-7acf-4b15-89c6-4970c153070a", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRacuna_RacunId",
                table: "StavkeRacuna",
                column: "RacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KupacId",
                table: "Racun",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_ZaglavljeId",
                table: "Racun",
                column: "ZaglavljeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeRacuna_Racun_RacunId",
                table: "StavkeRacuna",
                column: "RacunId",
                principalTable: "Racun",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkeRacuna_Racun_RacunId",
                table: "StavkeRacuna");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropIndex(
                name: "IX_StavkeRacuna_RacunId",
                table: "StavkeRacuna");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b53666-999c-4cb6-a51e-2f54d523cb20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eedb5755-7acf-4b15-89c6-4970c153070a");

            migrationBuilder.DropColumn(
                name: "RacunId",
                table: "StavkeRacuna");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90744163-df3e-4dc0-a419-2575d075114c", null, "User", "USER" },
                    { "9da1e5c9-b0e7-4ac6-bf49-4111dfea6ef4", null, "Admin", "ADMIN" }
                });
        }
    }
}
