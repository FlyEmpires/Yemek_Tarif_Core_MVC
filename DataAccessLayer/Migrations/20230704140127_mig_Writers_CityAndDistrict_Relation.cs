using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_Writers_CityAndDistrict_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Writers",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictID",
                table: "Writers",
                type: "int",
                nullable: true,
                defaultValue: 0);

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
                principalColumn: "Id",
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

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "DistrictID",
                table: "Writers");
        }
    }
}
