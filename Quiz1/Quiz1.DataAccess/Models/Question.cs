using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz1.DataAccess.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuizId { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
