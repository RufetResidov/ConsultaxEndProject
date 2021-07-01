using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaxMVC.Migrations
{
    public partial class Changed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "CustomerSayProjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "CustomerSayProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
