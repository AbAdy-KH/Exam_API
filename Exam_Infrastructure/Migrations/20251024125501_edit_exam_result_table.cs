using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit_exam_result_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExamResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExamResults",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
