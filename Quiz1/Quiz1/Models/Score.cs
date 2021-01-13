using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.Models
{
    public class Score
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreId { get; set; }

        [BindProperty]
        [ForeignKey("Id")]
        public string UserId { get; set; }

        [ForeignKey("QuizId")]
        public int QuizId { get; set; }

        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }

        [ForeignKey("AnswerId")]
        public int UserChoiceId { get; set; }

        [DisplayName("Correct")]
        public bool IsCorrect { get; set; }

        public List<Quiz> Quizzes { get; set; }
        public List<Question> Questions { get; set; }
        public List<int> UserChoices { get; set; }


    }
}
