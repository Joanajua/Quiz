using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Quiz1.ViewModels.QuizViewModels;

namespace Quiz1.Validators
{
    public class EditViewModelValidator : AbstractValidator<CreateViewModel>
    {
        public EditViewModelValidator(AppDbContext context)
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleForEach(q => q.Questions).SetValidator(new QuestionValidator());
        }
    }
}
