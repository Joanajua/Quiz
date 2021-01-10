using System.Collections.Generic;
using Quiz1.Models;

namespace Quiz1.ViewModels
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            Questions = new List<Question>();
            Answers = new List<Question>();
        }

        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Question> Answers { get; set; }
    }
}
