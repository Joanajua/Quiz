using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.Models
{
    public class Quiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizId { get; set; }

        //[Required(ErrorMessage = "Please enter a title")]
        //[MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        public List<Question> Questions { get; set; }
    }
}
