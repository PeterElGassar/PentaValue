using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AddCandidatProfile_FK_CandidateCareerInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateProfileId",
                table: "CandidateCareerInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCareerInfos_CandidateProfileId",
                table: "CandidateCareerInfos",
                column: "CandidateProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateCareerInfos_CandidateProfiles_CandidateProfileId",
                table: "CandidateCareerInfos",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateCareerInfos_CandidateProfiles_CandidateProfileId",
                table: "CandidateCareerInfos");

            migrationBuilder.DropIndex(
                name: "IX_CandidateCareerInfos_CandidateProfileId",
                table: "CandidateCareerInfos");

            migrationBuilder.DropColumn(
                name: "CandidateProfileId",
                table: "CandidateCareerInfos");
        }
    }
}
