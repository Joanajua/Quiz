using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quiz1.Models;

namespace Quiz1.ViewModels.QuizViewModels
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            Questions = new List<Question>
            {
                new Question()
                {
                    Answers = new List<Answer> { new Answer(), new Answer(), new Answer(), new Answer() }
                },
                new Question()
                {
                    Answers = new List<Answer> { new Answer(), new Answer(), new Answer(), new Answer() }
                },
                new Question()
                {
                    Answers = new List<Answer> { new Answer(), new Answer(), new Answer(), new Answer() }
                }
            };

            Errors = new List<string>();
        }

        public string Title { get; set; }

        public List<Question> Questions { get; set; }

        public List<string> Errors { get; set; }

    }
}
