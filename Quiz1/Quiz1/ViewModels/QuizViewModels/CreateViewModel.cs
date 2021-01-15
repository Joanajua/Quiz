using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Quiz1.Models;

namespace Quiz1.ViewModels.QuizViewModels
{
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>
        {
            new Question()
            {
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer()
                }
            },
            new Question()
            {
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer()
                }
            },
            new Question()
            {
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer()
                }
            },
            new Question()
            {
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer()
                }
            },
        };

        //public List<Answer> Answers { get; set; } = new List<Answer>
        //{
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer(),
        //    new Answer()
        //};

        //public Quiz Quiz { get; set; }

    }
}
