using Microsoft.EntityFrameworkCore.Migrations;

namespace xSoftBackend.Migrations
{
    public partial class josdetalja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutorKnjige",
                table: "Knjiga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GodinaIzdavanja",
                table: "Knjiga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Jezik",
                table: "Knjiga",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorKnjige",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "GodinaIzdavanja",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "Jezik",
                table: "Knjiga");
        }
    }
}
