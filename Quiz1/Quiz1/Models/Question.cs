using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.DataAccess.Models
{
    public class Question
    {
        [BindProperty]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please enter a Question.")]
        [DisplayName("Question")]
        [StringLength(500)]
        public string QuestionText { get; set; }

        [BindProperty]
        [ScaffoldColumn(false)]
        public int QuizId { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
