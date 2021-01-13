using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Quiz1.Migrations
{
    public partial class AddScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: true),
                    QuizId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    UserChoiceId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Scores_AspNetUsers_Id",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Answers_AnswerId",
                        column: x => x.UserChoiceId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 36,
                column: "QuestionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 37,
                column: "QuestionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 38,
                column: "QuestionId",
                value: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 36,
                column: "QuestionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 37,
                column: "QuestionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 38,
                column: "QuestionId",
                value: 10);
        }
    }
}
