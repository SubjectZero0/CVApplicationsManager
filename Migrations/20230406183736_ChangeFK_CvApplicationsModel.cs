using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVApplicationsManager.Migrations
{
    public partial class ChangeFK_CvApplicationsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CvApplications_Degrees_DegreesModel",
                table: "CvApplications");

            migrationBuilder.DropIndex(
                name: "IX_CvApplications_DegreesModel",
                table: "CvApplications");

            migrationBuilder.DropColumn(
                name: "DegreesModel",
                table: "CvApplications");

            migrationBuilder.CreateIndex(
                name: "IX_CvApplications_DegreeId",
                table: "CvApplications",
                column: "DegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CvApplications_Degrees_DegreeId",
                table: "CvApplications",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CvApplications_Degrees_DegreeId",
                table: "CvApplications");

            migrationBuilder.DropIndex(
                name: "IX_CvApplications_DegreeId",
                table: "CvApplications");

            migrationBuilder.AddColumn<int>(
                name: "DegreesModel",
                table: "CvApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CvApplications_DegreesModel",
                table: "CvApplications",
                column: "DegreesModel");

            migrationBuilder.AddForeignKey(
                name: "FK_CvApplications_Degrees_DegreesModel",
                table: "CvApplications",
                column: "DegreesModel",
                principalTable: "Degrees",
                principalColumn: "Id");
        }
    }
}
