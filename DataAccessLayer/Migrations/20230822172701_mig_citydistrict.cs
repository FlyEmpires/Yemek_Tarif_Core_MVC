using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_citydistrict : Migration
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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_Districts_DistrictID",
                table: "Writers",
                column: "DistrictID",
                principalTable: "Districts",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.NoAction);
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
