using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quiz1.Models;

namespace Quiz1.ViewModels.QuizViewModels
{
    public class DetailsViewModel
    {
        public Quiz Quiz { get; set; }

        [Required]
        public IEnumerable<Question> Questions { get; set; }
    }
}
