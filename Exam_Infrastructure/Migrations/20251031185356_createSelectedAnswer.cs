using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createSelectedAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamResultId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedAnswers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedAnswers");
        }
    }
}
