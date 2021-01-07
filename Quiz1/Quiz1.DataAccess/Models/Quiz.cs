using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.DataAccess.Models
{
    public class Quiz
    {
        [BindProperty]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizId { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(100)]
        public string QuizTitle { get; set; }

        public List<Question> Questions { get; set; }
    }
}
