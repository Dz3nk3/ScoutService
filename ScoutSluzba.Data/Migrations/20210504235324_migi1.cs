using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutSluzba.Data.Migrations
{
    public partial class migi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oznaka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Greska",
                columns: table => new
                {
                    GreskaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    greska = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrijemeGreske = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greska", x => x.GreskaID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oznaka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "korisnickiNalog",
                columns: table => new
                {
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipKorisnickogNaloga = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnickiNalog", x => x.KorisnickiNalogID);
                });

            migrationBuilder.CreateTable(
                name: "Liga",
                columns: table => new
                {
                    LigaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sampion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrTimova = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liga", x => x.LigaID);
                });

            migrationBuilder.CreateTable(
                name: "Specifikacija",
                columns: table => new
                {
                    SpecifikacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojPogodaka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojKornera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojSlobodnih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrOffside = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrveniKarton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZutiKarton = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifikacija", x => x.SpecifikacijaID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostanskiBr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trener = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stadion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    President = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LigaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Team_Liga_LigaID",
                        column: x => x.LigaID,
                        principalTable: "Liga",
                        principalColumn: "LigaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    LokacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.LokacijaID);
                    table.ForeignKey(
                        name: "FK_Lokacija_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    ZaposlenikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontakt_br = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum_rodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ZaposlenikID);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_korisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "korisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Igrac",
                columns: table => new
                {
                    IgracID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tezina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum_rodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    SpecifikacijaID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrac", x => x.IgracID);
                    table.ForeignKey(
                        name: "FK_Igrac_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Igrac_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Igrac_Specifikacija_SpecifikacijaID",
                        column: x => x.SpecifikacijaID,
                        principalTable: "Specifikacija",
                        principalColumn: "SpecifikacijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Igrac_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OcjenaKomentar",
                columns: table => new
                {
                    OcjenaKomentarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZaposlenikID = table.Column<int>(type: "int", nullable: false),
                    IgracID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcjenaKomentar", x => x.OcjenaKomentarID);
                    table.ForeignKey(
                        name: "FK_OcjenaKomentar_Igrac_IgracID",
                        column: x => x.IgracID,
                        principalTable: "Igrac",
                        principalColumn: "IgracID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OcjenaKomentar_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ZaposlenikID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Igrac_GradID",
                table: "Igrac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Igrac_KategorijaID",
                table: "Igrac",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Igrac_SpecifikacijaID",
                table: "Igrac",
                column: "SpecifikacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Igrac_TeamID",
                table: "Igrac",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_GradID",
                table: "Lokacija",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_OcjenaKomentar_IgracID",
                table: "OcjenaKomentar",
                column: "IgracID");

            migrationBuilder.CreateIndex(
                name: "IX_OcjenaKomentar_ZaposlenikID",
                table: "OcjenaKomentar",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LigaID",
                table: "Team",
                column: "LigaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_GradID",
                table: "Zaposlenik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_KorisnickiNalogID",
                table: "Zaposlenik",
                column: "KorisnickiNalogID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Greska");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "OcjenaKomentar");

            migrationBuilder.DropTable(
                name: "Igrac");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Specifikacija");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "korisnickiNalog");

            migrationBuilder.DropTable(
                name: "Liga");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
