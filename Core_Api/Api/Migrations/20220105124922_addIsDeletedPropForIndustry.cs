using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class addIsDeletedPropForIndustry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Industries",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Industries");
        }
    }
}
