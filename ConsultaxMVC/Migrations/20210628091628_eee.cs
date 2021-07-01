using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaxMVC.Migrations
{
    public partial class eee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Testimonials",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Testimonials");
        }
    }
}
