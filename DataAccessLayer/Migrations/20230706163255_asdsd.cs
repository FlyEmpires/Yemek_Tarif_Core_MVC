using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class asdsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Recipes_RecipeReceipeID",
            //    table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipeReceipeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReceipeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RecipeReceipeID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceipeID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeReceipeID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipeReceipeID",
                table: "Comments",
                column: "RecipeReceipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Recipes_RecipeReceipeID",
                table: "Comments",
                column: "RecipeReceipeID",
                principalTable: "Recipes",
                principalColumn: "ReceipeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
