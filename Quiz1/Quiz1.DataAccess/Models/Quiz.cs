using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz1.DataAccess.Models
{
    public class Quiz
    {
        public string QuizId { get; set; }
        public string QuizTitle { get; set; }

        public List<Question> Questions { get; set; }
    }
}
