using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Quiz1.Models;

namespace Quiz1.Validators
{
    public class AnswerValidator : AbstractValidator<Answer>
    {
        public AnswerValidator()
        {
            RuleFor(q => q.AnswerText)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
