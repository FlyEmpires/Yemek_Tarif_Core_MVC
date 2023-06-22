using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_writer_recipe_relation_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Recipes",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_WriterID",
                table: "Recipes",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Writers_WriterID",
                table: "Recipes",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Writers_WriterID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_WriterID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Recipes");
        }
    }
}
