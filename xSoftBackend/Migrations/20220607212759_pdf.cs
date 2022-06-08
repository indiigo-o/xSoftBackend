﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace xSoftBackend.Migrations
{
    public partial class pdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Knjigapdf",
                table: "Knjiga",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Knjigapdf",
                table: "Knjiga");
        }
    }
}
