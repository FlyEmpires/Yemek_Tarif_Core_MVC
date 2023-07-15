using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccessLayer.Migrations
{
    public partial class comment_silbastan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new
            {
                CommentID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CommentUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CommentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                CommentStatus = table.Column<bool>(type: "bit", nullable: false),
                ReceipeID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.CommentID);
                table.ForeignKey(
                    name: "FK_Comments_Recipes_ReceipeID",
                    column: x => x.ReceipeID,
                    principalTable: "Recipes",
                    principalColumn: "ReceipeID",
                    onDelete: ReferentialAction.Cascade);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
