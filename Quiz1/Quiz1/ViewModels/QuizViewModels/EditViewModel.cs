using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quiz1.Models;

namespace Quiz1.ViewModels.QuizViewModels
{
    public class EditViewModel
    {
        public EditViewModel()
        {
            Quiz = new Quiz
            {
                Questions = new List<Question>()
            };

            Errors = new List<string>();
        }

        public Quiz Quiz { get; set; }

        public List<string> Errors { get; set; }

    }
}
