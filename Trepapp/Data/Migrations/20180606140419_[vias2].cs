using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trepapp.Data.Migrations
{
    public partial class vias2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Via_Sector_SectorId",
                table: "Via");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Via");

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "Via",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Via_Sector_SectorId",
                table: "Via",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Via_Sector_SectorId",
                table: "Via");

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "Via",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Via",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Via_Sector_SectorId",
                table: "Via",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
