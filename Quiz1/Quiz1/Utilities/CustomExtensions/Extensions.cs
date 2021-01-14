using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;

namespace Quiz1.Utilities.CustomExtensions
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var random = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class ModelBuilderExtensions
    {
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
            new Answer {AnswerId = 1,  QuestionId = 1, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 2,  QuestionId = 1, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 3,  QuestionId = 1, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 4,  QuestionId = 1, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 5,  QuestionId = 2, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 6,  QuestionId = 2, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 7,  QuestionId = 2, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 8,  QuestionId = 3, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 9,  QuestionId = 3, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 10,  QuestionId = 3, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 11,  QuestionId = 3, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 12,  QuestionId = 4, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 13,  QuestionId = 4, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 14,  QuestionId = 4, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 15,  QuestionId = 5, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 16,  QuestionId = 5, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 17,  QuestionId = 5, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 18,  QuestionId = 5, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 19,  QuestionId = 6, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 20,  QuestionId = 6, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 21,  QuestionId = 6, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 22,  QuestionId = 7, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 23,  QuestionId = 7, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 24,  QuestionId = 7, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 25,  QuestionId = 7, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 26,  QuestionId = 8, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 27,  QuestionId = 8, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 28,  QuestionId = 8, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 29,  QuestionId = 9, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 30,  QuestionId = 9, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 31,  QuestionId = 9, AnswerText = "Answer 3", IsCorrect = false},

            new Answer {AnswerId = 32,  QuestionId = 10, AnswerText = "Answer 1", IsCorrect = false},
            new Answer {AnswerId = 33,  QuestionId = 10, AnswerText = "Answer 2", IsCorrect = true},
            new Answer {AnswerId = 34,  QuestionId = 10, AnswerText = "Answer 3", IsCorrect = false},
            new Answer {AnswerId = 35,  QuestionId = 10, AnswerText = "Answer 4", IsCorrect = false},

            new Answer {AnswerId = 36,  QuestionId = 11, AnswerText = "Answer 1", IsCorrect = true},
            new Answer {AnswerId = 37,  QuestionId = 11, AnswerText = "Answer 2", IsCorrect = false},
            new Answer {AnswerId = 38,  QuestionId = 11, AnswerText = "Answer 3", IsCorrect = false},
        };

        //private static Answer[] _mockAnswers = new[]
        //{
        //    new Answer {AnswerId = 1, QuizId = 1, QuestionId = 1, AnswerText = "Answer 1", IsCorrect = true},
        //    new Answer {AnswerId = 2, QuizId = 1, QuestionId = 1, AnswerText = "Answer 2", IsCorrect = false},
        //    new Answer {AnswerId = 3, QuizId = 1, QuestionId = 1, AnswerText = "Answer 3", IsCorrect = false},
        //    new Answer {AnswerId = 4, QuizId = 1, QuestionId = 1, AnswerText = "Answer 4", IsCorrect = false},

        //    new Answer {AnswerId = 5, QuizId = 1, QuestionId = 2, AnswerText = "Answer 1", IsCorrect = false},
        //    new Answer {AnswerId = 6, QuizId = 1, QuestionId = 2, AnswerText = "Answer 2", IsCorrect = true},
        //    new Answer {AnswerId = 7, QuizId = 1, QuestionId = 2, AnswerText = "Answer 3", IsCorrect = false},

        //    new Answer {AnswerId = 8, QuizId = 1, QuestionId = 3, AnswerText = "Answer 1", IsCorrect = true},
        //    new Answer {AnswerId = 9, QuizId = 1, QuestionId = 3, AnswerText = "Answer 2", IsCorrect = false},
        //    new Answer {AnswerId = 10, QuizId = 1, QuestionId = 3, AnswerText = "Answer 3", IsCorrect = false},
        //    new Answer {AnswerId = 11, QuizId = 1, QuestionId = 3, AnswerText = "Answer 4", IsCorrect = false},

        //    new Answer {AnswerId = 12, QuizId = 1, QuestionId = 4, AnswerText = "Answer 1", IsCorrect = false},
        //    new Answer {AnswerId = 13, QuizId = 1, QuestionId = 4, AnswerText = "Answer 2", IsCorrect = true},
        //    new Answer {AnswerId = 14, QuizId = 1, QuestionId = 4, AnswerText = "Answer 3", IsCorrect = false},

        //    new Answer {AnswerId = 15, QuizId = 2, QuestionId = 5, AnswerText = "Answer 1", IsCorrect = true},
        //    new Answer {AnswerId = 16, QuizId = 2, QuestionId = 5, AnswerText = "Answer 2", IsCorrect = false},
        //    new Answer {AnswerId = 17, QuizId = 2, QuestionId = 5, AnswerText = "Answer 3", IsCorrect = false},
        //    new Answer {AnswerId = 18, QuizId = 2, QuestionId = 5, AnswerText = "Answer 4", IsCorrect = false},

        //    new Answer {AnswerId = 19, QuizId = 2, QuestionId = 6, AnswerText = "Answer 1", IsCorrect = false},
        //    new Answer {AnswerId = 20, QuizId = 2, QuestionId = 6, AnswerText = "Answer 2", IsCorrect = true},
        //    new Answer {AnswerId = 21, QuizId = 2, QuestionId = 6, AnswerText = "Answer 3", IsCorrect = false},

        //    new Answer {AnswerId = 22, QuizId = 2, QuestionId = 7, AnswerText = "Answer 1", IsCorrect = true},
        //    new Answer {AnswerId = 23, QuizId = 2, QuestionId = 7, AnswerText = "Answer 2", IsCorrect = false},
        //    new Answer {AnswerId = 24, QuizId = 2, QuestionId = 7, AnswerText = "Answer 3", IsCorrect = false},
        //    new Answer {AnswerId = 25, QuizId = 2, QuestionId = 7, AnswerText = "Answer 4", IsCorrect = false},

        //    new Answer {AnswerId = 26, QuizId = 2, QuestionId = 8, AnswerText = "Answer 1", IsCorrect = false},
        //    new Answer {AnswerId = 27, QuizId = 2, QuestionId = 8, AnswerText = "Answer 2", IsCorrect = true},
        //    new Answer {AnswerId = 28, QuizId = 2, QuestionId = 8, AnswerText = "Answer 3", IsCorrect = false},

        //    new Answer {AnswerId = 29, QuizId = 3, QuestionId = 9, AnswerText = "Answer 1", IsCorrect = true},
        //    new Answer {AnswerId = 30, QuizId = 3, QuestionId = 9, AnswerText = "Answer 2", IsCorrect = false},
        //    new Answer {AnswerId = 31, QuizId = 3, QuestionId = 9, AnswerText = "Answer 3", IsCorrect = false},

        //    new Answer {AnswerId = 32, QuizId = 3, QuestionId = 10, AnswerText = "Answer 1", IsCorrect = false},
        //    new Answer {AnswerId = 33, QuizId = 3, QuestionId = 10, AnswerText = "Answer 2", IsCorrect = true},
        //    new Answer {AnswerId = 34, QuizId = 3, QuestionId = 10, AnswerText = "Answer 3", IsCorrect = false},
        //    new Answer {AnswerId = 35, QuizId = 3, QuestionId = 10, AnswerText = "Answer 4", IsCorrect = false},

        //    new Answer {AnswerId = 36, QuizId = 3, QuestionId = 11, AnswerText = "Answer 1", IsCorrect = true},
        //    new Answer {AnswerId = 37, QuizId = 3, QuestionId = 11, AnswerText = "Answer 2", IsCorrect = false},
        //    new Answer {AnswerId = 38, QuizId = 3, QuestionId = 11, AnswerText = "Answer 3", IsCorrect = false},
        //};

        //private static IdentityRole[] _mockRoles = new[]
        //{
        //    new IdentityRole {Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6", Name = "Admin", NormalizedName = "ADMIN"},
        //    new IdentityRole {Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "RO-User", NormalizedName = "RO-USER"},
        //    new IdentityRole {Id = "341743f0-asd2–42de-atsy-59kmkkmk72cf6", Name = "PO-User", NormalizedName = "PO-USER"},
        //};

        //private static PasswordHasher<IdentityUser> _passwordHasher = new PasswordHasher<IdentityUser>();

        ////private static UserManager<IdentityUser> _userManager;
        ////private static RoleManager<IdentityRole> _roleManager;

        //private static IdentityUser[] _mockUsers = new[]
        //{
        ////    new IdentityUser()
        ////    {
        ////        Id = "37874cf0–9412–4cfe-afbf-59f706d72cf6", // primary key
        ////        UserName = "admin@mailinator.com",
        ////        NormalizedUserName = "ADMIN@MAILINATOR.com",
        ////        Email = "admin@mailinator.com",
        ////        NormalizedEmail = "ADMIN@MAILINATOR.com",
        ////        PasswordHash = _passwordHasher.HashPassword(null, "Abcd123456@"),
        ////    },
        ////    new IdentityUser
        ////    {
        ////        Id = "55664cf0–9412–4cfe-afbf-59f706d72cf6", // primary key
        ////        UserName = "ro-user@mailinator.com",
        ////        NormalizedUserName = "RO-USER@MAILINATOR",
        ////        Email = "ro-user@mailinator.com",
        ////        NormalizedEmail = "RO-USER@MAILINATOR",
        ////        PasswordHash = _passwordHasher.HashPassword(null, "Abcd123456@")
        ////    },
        //    new IdentityUser
        //    {
        //        Id = "88884cf0–9412–4cfe-afbf-59f706d72cf6", // primary key
        //        UserName = "po-user@mailinator.com",
        //        NormalizedUserName = "PO-USER@MAILINATOR",
        //        Email = "po-user@mailinator.com",
        //        NormalizedEmail = "PO-USER@MAILINATOR",
        //        PasswordHash = _passwordHasher.HashPassword(null, "Abcd123456@")
        //    }
        //};

        ////private static IdentityUserRole<string>[] _mockUserRolesRelation = new[]
        ////{
        ////    new IdentityUserRole<string>
        ////    {
        ////        RoleId = "02174cf0–9412–4cfe-afbf-59f706d72cf6", // for admin - ro-user@mailinator.com username
        ////        UserId = "37874cf0–9412–4cfe-afbf-59f706d72cf6" // for admin role
        ////    },
        ////    new IdentityUserRole<string>
        ////    {
        ////        RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", // for Ro-User - ro-user@mailinator.com username
        ////        UserId = "55664cf0–9412–4cfe-afbf-59f706d72cf6" // for ReadOnly role
        ////    },
        ////    new IdentityUserRole<string>
        ////    {
        ////        RoleId = "341743f0-asd2–42de-atsy-59kmkkmk72cf6", // for Ro-User - po-user@mailinator.com username
        ////        UserId = "88884cf0–9412–4cfe-afbf-59f706d72cf6" // for PlayOnly role
        ////    }
        ////};

        public static void Seed (this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasData(_mockQuizzes);
            modelBuilder.Entity<Question>().HasData(_mockQuestions);
            modelBuilder.Entity<Answer>().HasData(_mockAnswers);
            //modelBuilder.Entity<IdentityRole>().HasData(_mockRoles);
            //modelBuilder.Entity<IdentityUser>().HasData(_mockUsers);
            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(_mockUserRolesRelation);
        }
    }
}
