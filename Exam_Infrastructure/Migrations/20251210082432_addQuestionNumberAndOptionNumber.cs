using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addQuestionNumberAndOptionNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptionNumber",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "1",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "10",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "11",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "12",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "2",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "3",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "4",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "5",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "6",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "7",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "8",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "9",
                column: "OptionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: "1",
                column: "QuestionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: "2",
                column: "QuestionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: "3",
                column: "QuestionNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: "4",
                column: "QuestionNumber",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "OptionNumber",
                table: "Options");
        }
    }
}
