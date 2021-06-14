using Microsoft.EntityFrameworkCore.Migrations;

namespace Autobiography.Data.Migrations
{
    public partial class AddPropertyPresent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Present",
                table: "Educations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Present",
                table: "Educations");
        }
    }
}
