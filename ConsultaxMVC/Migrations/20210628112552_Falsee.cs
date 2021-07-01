using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultaxMVC.Migrations
{
    public partial class Falsee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_whoWeAres",
                table: "whoWeAres");

            migrationBuilder.RenameTable(
                name: "whoWeAres",
                newName: "WhoWeAres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhoWeAres",
                table: "WhoWeAres",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CustomerSayProjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSayProjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DetailsProjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsProjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedProjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedProjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PictureProjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureProjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProsesWorks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProsesWorks", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSayProjects");

            migrationBuilder.DropTable(
                name: "DetailsProjects");

            migrationBuilder.DropTable(
                name: "FeaturedProjects");

            migrationBuilder.DropTable(
                name: "PictureProjects");

            migrationBuilder.DropTable(
                name: "ProsesWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WhoWeAres",
                table: "WhoWeAres");

            migrationBuilder.RenameTable(
                name: "WhoWeAres",
                newName: "whoWeAres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_whoWeAres",
                table: "whoWeAres",
                column: "ID");
        }
    }
}
