using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class addIsDeletedPropForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProfileCandidatePhonNumbers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyProfiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyPhoneNumbers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyIndustries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyAddresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CandidateProfiles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProfileCandidatePhonNumbers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyIndustries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CandidateProfiles");
        }
    }
}
