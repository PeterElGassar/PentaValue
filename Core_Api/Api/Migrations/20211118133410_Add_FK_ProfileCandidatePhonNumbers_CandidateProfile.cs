using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Add_FK_ProfileCandidatePhonNumbers_CandidateProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateProfileId",
                table: "ProfileCandidatePhonNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileCandidatePhonNumbers_CandidateProfileId",
                table: "ProfileCandidatePhonNumbers",
                column: "CandidateProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileCandidatePhonNumbers_CandidateProfiles_CandidateProfileId",
                table: "ProfileCandidatePhonNumbers",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileCandidatePhonNumbers_CandidateProfiles_CandidateProfileId",
                table: "ProfileCandidatePhonNumbers");

            migrationBuilder.DropIndex(
                name: "IX_ProfileCandidatePhonNumbers_CandidateProfileId",
                table: "ProfileCandidatePhonNumbers");

            migrationBuilder.DropColumn(
                name: "CandidateProfileId",
                table: "ProfileCandidatePhonNumbers");
        }
    }
}
