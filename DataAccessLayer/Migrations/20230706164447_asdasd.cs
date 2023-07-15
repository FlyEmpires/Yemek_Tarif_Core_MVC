using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipeID",
                table: "Comments",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Recipes_RecipeID",
                table: "Comments",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "ReceipeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Recipes_RecipeID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Comments");
        }
    }
}
