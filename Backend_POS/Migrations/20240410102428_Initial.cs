using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_POS.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ŠIFRA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAZIV = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADRESA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MJESTO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ŠIFRA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAZIV = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JEDINICA_MJERE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CIJENA = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    STANJE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zaglavlje_racuna",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BROJ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATUM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NAPOMENA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    KupacID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaglavlje_racuna", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zaglavlje_racuna_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaglavlje_racuna_Kupac_KupacID1",
                        column: x => x.KupacID1,
                        principalTable: "Kupac",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stavke_racuna",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KOLICINA = table.Column<int>(type: "int", nullable: false),
                    CIJENA = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    POPUST = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IZNOS_POPUSTA = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    VRIJEDNOST = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    Zaglavlje_racunaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavke_racuna", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stavke_racuna_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stavke_racuna_Proizvod_ProizvodID1",
                        column: x => x.ProizvodID1,
                        principalTable: "Proizvod",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Stavke_racuna_Zaglavlje_racuna_Zaglavlje_racunaID",
                        column: x => x.Zaglavlje_racunaID,
                        principalTable: "Zaglavlje_racuna",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_racuna_ProizvodID",
                table: "Stavke_racuna",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_racuna_ProizvodID1",
                table: "Stavke_racuna",
                column: "ProizvodID1");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_racuna_Zaglavlje_racunaID",
                table: "Stavke_racuna",
                column: "Zaglavlje_racunaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaglavlje_racuna_KupacID",
                table: "Zaglavlje_racuna",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaglavlje_racuna_KupacID1",
                table: "Zaglavlje_racuna",
                column: "KupacID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stavke_racuna");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Zaglavlje_racuna");

            migrationBuilder.DropTable(
                name: "Kupac");
        }
    }
}
