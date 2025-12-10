using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyConstraintsInSavedExamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SavedExams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ExamId",
                table: "SavedExams",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SavedExams_ExamId",
                table: "SavedExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedExams_UserId",
                table: "SavedExams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedExams_AspNetUsers_UserId",
                table: "SavedExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedExams_Exams_ExamId",
                table: "SavedExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedExams_AspNetUsers_UserId",
                table: "SavedExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedExams_Exams_ExamId",
                table: "SavedExams");

            migrationBuilder.DropIndex(
                name: "IX_SavedExams_ExamId",
                table: "SavedExams");

            migrationBuilder.DropIndex(
                name: "IX_SavedExams_UserId",
                table: "SavedExams");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SavedExams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ExamId",
                table: "SavedExams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
