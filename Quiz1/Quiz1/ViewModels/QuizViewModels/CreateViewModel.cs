using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quiz1.Models;

namespace Quiz1.ViewModels.QuizViewModels
{
    public class CreateViewModel
    {
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

        [Required]
        public IEnumerable<Question> Questions { get; set; }
    }
}
