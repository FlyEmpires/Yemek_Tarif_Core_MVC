using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_Relation_AppUsersWithRecipe2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AppUserID",
                table: "Recipes",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_AppUserID",
                table: "Recipes",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_AppUserID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AppUserID",
                table: "Recipes");
        }
    }
}
