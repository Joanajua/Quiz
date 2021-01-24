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
            Errors = new List<string>();
        }

        public Quiz Quiz { get; set; }

        public IEnumerable<Question> Questions { get; set; }

        public List<string> Errors { get; set; }

    }
}
