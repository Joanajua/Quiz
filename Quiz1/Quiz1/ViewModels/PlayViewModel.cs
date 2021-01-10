using System.Collections.Generic;
using Quiz1.Models;

namespace Quiz1.ViewModels
{
    public class PlayViewModel
    {
        public Quiz Quiz { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? WrongAnswers { get; set; }

        public IEnumerable<Question> Questions { get; set; }
        //public IEnumerable<Answer> Answers { get; set; }

    }
}
