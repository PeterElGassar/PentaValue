using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Add_FKS_ProfileCompanyChildTBLs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileId",
                table: "CompanyPhoneNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileId",
                table: "CompanyIndustries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileId",
                table: "CompanyAddresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhoneNumbers_CompanyProfileId",
                table: "CompanyPhoneNumbers",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustries_CompanyProfileId",
                table: "CompanyIndustries",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CompanyProfileId",
                table: "CompanyAddresses",
                column: "CompanyProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAddresses_CompanyProfiles_CompanyProfileId",
                table: "CompanyAddresses",
                column: "CompanyProfileId",
                principalTable: "CompanyProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyIndustries_CompanyProfiles_CompanyProfileId",
                table: "CompanyIndustries",
                column: "CompanyProfileId",
                principalTable: "CompanyProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPhoneNumbers_CompanyProfiles_CompanyProfileId",
                table: "CompanyPhoneNumbers",
                column: "CompanyProfileId",
                principalTable: "CompanyProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAddresses_CompanyProfiles_CompanyProfileId",
                table: "CompanyAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyIndustries_CompanyProfiles_CompanyProfileId",
                table: "CompanyIndustries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPhoneNumbers_CompanyProfiles_CompanyProfileId",
                table: "CompanyPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyPhoneNumbers_CompanyProfileId",
                table: "CompanyPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyIndustries_CompanyProfileId",
                table: "CompanyIndustries");

            migrationBuilder.DropIndex(
                name: "IX_CompanyAddresses_CompanyProfileId",
                table: "CompanyAddresses");

            migrationBuilder.DropColumn(
                name: "CompanyProfileId",
                table: "CompanyPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "CompanyProfileId",
                table: "CompanyIndustries");

            migrationBuilder.DropColumn(
                name: "CompanyProfileId",
                table: "CompanyAddresses");
        }
    }
}
