using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Receipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipes_CategoryID",
                table: "Receipes",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipes_Categories_CategoryID",
                table: "Receipes",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipes_Categories_CategoryID",
                table: "Receipes");

            migrationBuilder.DropIndex(
                name: "IX_Receipes_CategoryID",
                table: "Receipes");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Receipes");
        }
    }
}
