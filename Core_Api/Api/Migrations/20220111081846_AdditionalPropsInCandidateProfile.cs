using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class AdditionalPropsInCandidateProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "CandidateProfiles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "CandidateProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationalty",
                table: "CandidateProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "CandidateProfiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "CandidateProfiles");

            migrationBuilder.DropColumn(
                name: "Nationalty",
                table: "CandidateProfiles");
        }
    }
}
