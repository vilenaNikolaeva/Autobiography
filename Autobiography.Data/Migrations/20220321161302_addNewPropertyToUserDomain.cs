using Microsoft.EntityFrameworkCore.Migrations;

namespace Autobiography.Data.Migrations
{
    public partial class addNewPropertyToUserDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClTemplate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CvTemplate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherConnections",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClTemplate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CvTemplate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OtherConnections",
                table: "AspNetUsers");
        }
    }
}
