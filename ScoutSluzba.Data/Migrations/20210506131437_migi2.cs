using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutSluzba.Data.Migrations
{
    public partial class migi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipZaposlenikaID",
                table: "Zaposlenik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipZaposlenika",
                columns: table => new
                {
                    TipZaposlenikaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZaposlenika", x => x.TipZaposlenikaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_TipZaposlenikaID",
                table: "Zaposlenik",
                column: "TipZaposlenikaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaposlenik_TipZaposlenika_TipZaposlenikaID",
                table: "Zaposlenik",
                column: "TipZaposlenikaID",
                principalTable: "TipZaposlenika",
                principalColumn: "TipZaposlenikaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaposlenik_TipZaposlenika_TipZaposlenikaID",
                table: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "TipZaposlenika");

            migrationBuilder.DropIndex(
                name: "IX_Zaposlenik_TipZaposlenikaID",
                table: "Zaposlenik");

            migrationBuilder.DropColumn(
                name: "TipZaposlenikaID",
                table: "Zaposlenik");
        }
    }
}
