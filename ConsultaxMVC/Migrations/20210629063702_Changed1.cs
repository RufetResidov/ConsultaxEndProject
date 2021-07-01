using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaxMVC.Migrations
{
    public partial class Changed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoTitle",
                table: "DetailsProjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoTitle",
                table: "DetailsProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
