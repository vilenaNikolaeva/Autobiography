using Microsoft.EntityFrameworkCore.Migrations;

namespace Autobiography.Data.Migrations
{
    public partial class AddPropertyStillWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StillWork",
                table: "Experiences",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StillWork",
                table: "Experiences");
        }
    }
}
