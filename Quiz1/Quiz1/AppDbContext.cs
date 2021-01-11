using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;
using Quiz1.ViewModels;

namespace Quiz1
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // Conditional to migrate database when is not in testing
            //if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            //{
            Database.Migrate();
            //}
        }

        // For unit test a need to set these methods a virtual to override them
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public DbSet<Result> Results { get; set; }


        private static Quiz[] _mockQuizzes = new[]
        {
            new Quiz {QuizId = 1, Title = "Quiz 1"},
            new Quiz {QuizId = 2, Title = "Quiz 2"},
            new Quiz {QuizId = 3, Title = "Quiz 3"},
        };

        private static Question[] _mockQuestions = new[]
        {
            new Question {QuestionId = 1, QuizId = 1, QuestionText = "Question 1"},
            new Question {QuestionId = 2, QuizId = 1, QuestionText = "Question 2"},
            new Question {QuestionId = 3, QuizId = 1, QuestionText = "Question 3"},
            new Question {QuestionId = 4, QuizId = 1, QuestionText = "Question 4"},

            new Question {QuestionId = 5, QuizId = 2, QuestionText = "Question 1"},
            new Question {QuestionId = 6, QuizId = 2, QuestionText = "Question 2"},
            new Question {QuestionId = 7, QuizId = 2, QuestionText = "Question 3"},
            new Question {QuestionId = 8, QuizId = 2, QuestionText = "Question 4"},

            new Question {QuestionId = 9, QuizId = 3, QuestionText = "Question 1"},
            new Question {QuestionId = 10, QuizId = 3, QuestionText = "Question 2"},
            new Question {QuestionId = 11, QuizId = 3, QuestionText = "Question 3"},
        };

        private static Answer[] _mockAnswers = new[]
        {
            new Answer {AnswerId = 1, QuizId = 1, QuestionId = 1, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 2, QuizId = 1, QuestionId = 1, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 3, QuizId = 1, QuestionId = 1, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 4, QuizId = 1, QuestionId = 1, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 5, QuizId = 1, QuestionId = 2, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 6, QuizId = 1, QuestionId = 2, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 7, QuizId = 1, QuestionId = 2, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 8, QuizId = 1, QuestionId = 3, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 9, QuizId = 1, QuestionId = 3, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 10, QuizId = 1, QuestionId = 3, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 11, QuizId = 1, QuestionId = 3, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 12, QuizId = 1, QuestionId = 4, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 13, QuizId = 1, QuestionId = 4, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 14, QuizId = 1, QuestionId = 4, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 15, QuizId = 2, QuestionId = 5, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 16, QuizId = 2, QuestionId = 5, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 17, QuizId = 2, QuestionId = 5, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 18, QuizId = 2, QuestionId = 5, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 19, QuizId = 2, QuestionId = 6, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 20, QuizId = 2, QuestionId = 6, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 21, QuizId = 2, QuestionId = 6, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 22, QuizId = 2, QuestionId = 7, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 23, QuizId = 2, QuestionId = 7, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 24, QuizId = 2, QuestionId = 7, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 25, QuizId = 2, QuestionId = 7, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 26, QuizId = 2, QuestionId = 8, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 27, QuizId = 2, QuestionId = 8, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 28, QuizId = 2, QuestionId = 8, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 29, QuizId = 3, QuestionId = 9, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 30, QuizId = 3, QuestionId = 9, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 31, QuizId = 3, QuestionId = 9, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 32, QuizId = 3, QuestionId = 10, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 33, QuizId = 3, QuestionId = 10, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 34, QuizId = 3, QuestionId = 10, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 35, QuizId = 3, QuestionId = 10, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 36, QuizId = 3, QuestionId = 11, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 37, QuizId = 3, QuestionId = 11, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 38, QuizId = 3, QuestionId = 11, AnswerText = "Answer 3", IsCorrect = false},
        };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Quiz>().HasData(_mockQuizzes);
            modelBuilder.Entity<Question>().HasData(_mockQuestions);
            modelBuilder.Entity<Answer>().HasData(_mockAnswers);
        }
    }
}
