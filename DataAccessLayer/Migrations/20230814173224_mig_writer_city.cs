﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_writer_city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Writers_CityID",
                table: "Writers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Writers_DistrictID",
                table: "Writers",
                column: "DistrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_Cities_CityID",
                table: "Writers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_Districts_DistrictID",
                table: "Writers",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Writers_Cities_CityID",
                table: "Writers");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_Districts_DistrictID",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Writers_CityID",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Writers_DistrictID",
                table: "Writers");
        }
    }
}
