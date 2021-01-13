using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quiz1.Models;

namespace Quiz1.ViewModels.QuizViewModels
{
    public class DetailsViewModel
    {
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

        public int? CorrectAnswers { get; set; }
        public int? WrongAnswers { get; set; }

        [Required]
        public IEnumerable<Question> Questions { get; set; }
    }
}
