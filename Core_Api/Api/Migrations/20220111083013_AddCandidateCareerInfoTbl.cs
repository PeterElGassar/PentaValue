using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddCandidateCareerInfoTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateCareerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(nullable: true),
                    JobLevel = table.Column<string>(nullable: true),
                    JobNature = table.Column<string>(nullable: true),
                    Objective = table.Column<string>(nullable: true),
                    CurrentSalary = table.Column<int>(nullable: false),
                    ExpectedSalary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCareerInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateCareerInfos");
        }
    }
}
