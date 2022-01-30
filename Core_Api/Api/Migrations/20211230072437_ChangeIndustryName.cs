using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class ChangeIndustryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Industries");

            migrationBuilder.AddColumn<string>(
                name: "IndustryName",
                table: "Industries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndustryName",
                table: "Industries");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Industries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
