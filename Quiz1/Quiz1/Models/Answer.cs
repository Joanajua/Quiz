using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }

        //public int QuizId { get; set; }

        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please enter an answer.")]
        [DisplayName("Answer")]
        [StringLength(500)]
        public string AnswerText { get; set; }

        [DisplayName("Correct")]
        [DefaultValue(false)]
        public bool IsCorrect { get; set; }
    }
}
