using System.Collections.Generic;
using Quiz1.Models;

namespace Quiz1.ViewModels
{
    public class CardQuestionViewModel
    {
        public Question Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public int CorrectAnswerId { get; set; }

    }
}
