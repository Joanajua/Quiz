using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.Models
{
    public class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }

        [BindProperty]
        public string UserId { get; set; }

        public int QuizId { get; set; }

        public int QuestionId { get; set; }

        public int UserChoiceId { get; set; }

        [DisplayName("Correct")]
        public bool IsCorrect { get; set; }

        public List<Quiz> Quizzes { get; set; }
        public List<Question> Questions { get; set; }
        public List<int> UserChoices { get; set; }


    }
}
