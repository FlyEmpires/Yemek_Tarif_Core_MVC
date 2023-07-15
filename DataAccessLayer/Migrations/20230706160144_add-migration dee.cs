using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addmigrationdee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
           name: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
