using Microsoft.EntityFrameworkCore.Migrations;

namespace xSoftBackend.Migrations
{
    public partial class treca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Korisnik_korisnik_id",
                table: "Knjiga");

            migrationBuilder.DropIndex(
                name: "IX_Knjiga_korisnik_id",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "korisnik_id",
                table: "Knjiga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "korisnik_id",
                table: "Knjiga",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_korisnik_id",
                table: "Knjiga",
                column: "korisnik_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Korisnik_korisnik_id",
                table: "Knjiga",
                column: "korisnik_id",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
