using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a subtitle")]
        [StringLength(100)]
        public string Subtitle { get; set; }

        [Required(ErrorMessage = "Please enter a short description")]
        [StringLength(100)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Please enter a long description")]
        [StringLength(400)]
        public string LongDescription { get; set; }

        [DisplayName("Publishing time")]
        public DateTime? CreationTime { get; set; }

        public List<Question> Questions { get; set; }
    }
}
