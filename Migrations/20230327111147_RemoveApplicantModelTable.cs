using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVApplicationsManager.Migrations
{
    public partial class RemoveApplicantModelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Degrees_DegreesModel",
                table: "Applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Applicants");

            migrationBuilder.RenameTable(
                name: "Applicants",
                newName: "CvApplications");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_DegreesModel",
                table: "CvApplications",
                newName: "IX_CvApplications_DegreesModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CvApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CvApplications",
                table: "CvApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CvApplications_Degrees_DegreesModel",
                table: "CvApplications",
                column: "DegreesModel",
                principalTable: "Degrees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CvApplications_Degrees_DegreesModel",
                table: "CvApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CvApplications",
                table: "CvApplications");

            migrationBuilder.RenameTable(
                name: "CvApplications",
                newName: "Applicants");

            migrationBuilder.RenameIndex(
                name: "IX_CvApplications_DegreesModel",
                table: "Applicants",
                newName: "IX_Applicants_DegreesModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Applicants",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Degrees_DegreesModel",
                table: "Applicants",
                column: "DegreesModel",
                principalTable: "Degrees",
                principalColumn: "Id");
        }
    }
}
