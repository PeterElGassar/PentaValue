using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class ForeignKey_ProfilesForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "CompanyProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "CandidateProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_AppUserId",
                table: "CompanyProfiles",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProfiles_AppUserId",
                table: "CandidateProfiles",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateProfiles_AspNetUsers_AppUserId",
                table: "CandidateProfiles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProfiles_AspNetUsers_AppUserId",
                table: "CompanyProfiles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateProfiles_AspNetUsers_AppUserId",
                table: "CandidateProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProfiles_AspNetUsers_AppUserId",
                table: "CompanyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProfiles_AppUserId",
                table: "CompanyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CandidateProfiles_AppUserId",
                table: "CandidateProfiles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CandidateProfiles");
        }
    }
}
