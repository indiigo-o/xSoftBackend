using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xSoftBackend.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Knjiga_id = table.Column<int>(type: "int", nullable: false),
                    SadrzajKomentara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    korisnik_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentar_Knjiga_Knjiga_id",
                        column: x => x.Knjiga_id,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentar_Korisnik_korisnik_id",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_Knjiga_id",
                table: "Komentar",
                column: "Knjiga_id");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_korisnik_id",
                table: "Komentar",
                column: "korisnik_id");
        }
    }
}
