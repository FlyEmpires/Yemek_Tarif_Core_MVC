using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeReceipeID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
            name: "IX_Comments_RecipeReceipeID",
            table: "Comments",
            column: "RecipeReceipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
