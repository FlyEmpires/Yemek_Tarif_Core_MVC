using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_duzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Receipes_ReceipeID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Receipes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReceipeID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "RecipeReceipeID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ReceipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceipeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeIngredient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipeStatus = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ReceipeID);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipeReceipeID",
                table: "Comments",
                column: "RecipeReceipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryID",
                table: "Recipes",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Recipes_RecipeReceipeID",
                table: "Comments",
                column: "RecipeReceipeID",
                principalTable: "Recipes",
                principalColumn: "ReceipeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Recipes_RecipeReceipeID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RecipeReceipeID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RecipeReceipeID",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "Receipes",
                columns: table => new
                {
                    ReceipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceipeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeIngredient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceipeStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReceipeThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipes", x => x.ReceipeID);
                    table.ForeignKey(
                        name: "FK_Receipes_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReceipeID",
                table: "Comments",
                column: "ReceipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipes_CategoryID",
                table: "Receipes",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Receipes_ReceipeID",
                table: "Comments",
                column: "ReceipeID",
                principalTable: "Receipes",
                principalColumn: "ReceipeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
