using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz1.DataAccess.Models
{
    public class Answer
    {
        public string AnswerId { get; set; }
        public string QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        public List<Question> Questions { get; set; }
    }
}
