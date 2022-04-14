using Microsoft.EntityFrameworkCore.Migrations;

namespace Autobiography.Data.Migrations
{
    public partial class addNewProperiesToCoverLetterDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "CoverLetter",
                newName: "RecepientPhone");

            migrationBuilder.AddColumn<string>(
                name: "RecepientCompany",
                table: "CoverLetter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecepientDepartment",
                table: "CoverLetter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecepientEmail",
                table: "CoverLetter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecepientCompany",
                table: "CoverLetter");

            migrationBuilder.DropColumn(
                name: "RecepientDepartment",
                table: "CoverLetter");

            migrationBuilder.DropColumn(
                name: "RecepientEmail",
                table: "CoverLetter");

            migrationBuilder.RenameColumn(
                name: "RecepientPhone",
                table: "CoverLetter",
                newName: "Phone");
        }
    }
}
