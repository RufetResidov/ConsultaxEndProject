using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaxMVC.Migrations
{
    public partial class Changed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutLogos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutLogos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AboutSliders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSliders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AboutStatisticCounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countNum = table.Column<int>(type: "int", nullable: false),
                    TitleLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutStatisticCounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AboutWhatWeDos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutWhatWeDos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PagesContactUs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesContactUs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutLogos");

            migrationBuilder.DropTable(
                name: "AboutSliders");

            migrationBuilder.DropTable(
                name: "AboutStatisticCounts");

            migrationBuilder.DropTable(
                name: "AboutWhatWeDos");

            migrationBuilder.DropTable(
                name: "PagesContactUs");
        }
    }
}
