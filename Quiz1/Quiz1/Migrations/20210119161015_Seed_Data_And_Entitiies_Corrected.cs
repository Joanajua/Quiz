using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz1.Migrations
{
    public partial class Seed_Data_And_Entitiies_Corrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 11);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Questions",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "Answers",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 8,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 4", false, 2 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 9,
                column: "AnswerText",
                value: "Answer 1");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 10,
                column: "AnswerText",
                value: "Answer 2");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 11,
                columns: new[] { "AnswerText", "IsCorrect" },
                values: new object[] { "Answer 3", true });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 12,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 3 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 13,
                columns: new[] { "AnswerText", "IsCorrect" },
                values: new object[] { "Answer 1", false });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 14,
                column: "AnswerText",
                value: "Answer 2");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 15,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 4 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 16,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 4 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 17,
                column: "AnswerText",
                value: "Answer 1");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 18,
                column: "AnswerText",
                value: "Answer 2");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 19,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 5 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 20,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 5 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 21,
                column: "AnswerText",
                value: "Answer 1");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 22,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 2", 6 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 23,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 6 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 24,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 6 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 25,
                column: "AnswerText",
                value: "Answer 1");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 26,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 2", true, 7 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 27,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 3", false, 7 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 28,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 7 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 29,
                columns: new[] { "IsCorrect", "QuestionId" },
                values: new object[] { false, 8 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 30,
                column: "QuestionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 31,
                column: "QuestionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 32,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 4", true, 8 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 33,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 1", false, 9 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 34,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 2", 9 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 35,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 9 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 36,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 9 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                columns: new[] { "QuestionText", "QuizId" },
                values: new object[] { "Question 1", 2 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5,
                column: "QuestionText",
                value: "Question 2");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "QuestionText",
                value: "Question 3");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 7,
                columns: new[] { "QuestionText", "QuizId" },
                values: new object[] { "Question 1", 3 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 8,
                columns: new[] { "QuestionText", "QuizId" },
                values: new object[] { "Question 2", 3 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 9,
                column: "QuestionText",
                value: "Question 3");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "Answers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 8,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 1", true, 3 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 9,
                column: "AnswerText",
                value: "Answer 2");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 10,
                column: "AnswerText",
                value: "Answer 3");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 11,
                columns: new[] { "AnswerText", "IsCorrect" },
                values: new object[] { "Answer 4", false });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 12,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 1", 4 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 13,
                columns: new[] { "AnswerText", "IsCorrect" },
                values: new object[] { "Answer 2", true });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 14,
                column: "AnswerText",
                value: "Answer 3");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 15,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 1", 5 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 16,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 2", 5 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 17,
                column: "AnswerText",
                value: "Answer 3");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 18,
                column: "AnswerText",
                value: "Answer 4");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 19,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 1", 6 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 20,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 2", 6 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 21,
                column: "AnswerText",
                value: "Answer 3");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 22,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 1", 7 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 23,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 2", 7 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 24,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 7 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 25,
                column: "AnswerText",
                value: "Answer 4");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 26,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 1", false, 8 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 27,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 2", true, 8 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 28,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 8 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 29,
                columns: new[] { "IsCorrect", "QuestionId" },
                values: new object[] { true, 9 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 30,
                column: "QuestionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 31,
                column: "QuestionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                columns: new[] { "QuestionText", "QuizId" },
                values: new object[] { "Question 4", 1 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5,
                column: "QuestionText",
                value: "Question 1");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "QuestionText",
                value: "Question 2");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 7,
                columns: new[] { "QuestionText", "QuizId" },
                values: new object[] { "Question 3", 2 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 8,
                columns: new[] { "QuestionText", "QuizId" },
                values: new object[] { "Question 4", 2 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 9,
                column: "QuestionText",
                value: "Question 1");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText", "QuizId" },
                values: new object[,]
                {
                    { 11, "Question 3", 3 },
                    { 10, "Question 2", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 32,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 1", false, 10 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 33,
                columns: new[] { "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[] { "Answer 2", true, 10 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 34,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 3", 10 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 35,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 4", 10 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 36,
                columns: new[] { "AnswerText", "QuestionId" },
                values: new object[] { "Answer 1", 11 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 37, "Answer 2", false, 11 },
                    { 38, "Answer 3", false, 11 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
