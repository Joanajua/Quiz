using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Quiz1.Models;
using Quiz1.Utilities.Constants;

namespace Quiz1.Validators
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            // Validation for 1 question - A white space counts as empty
            // and a max length of 150
            RuleFor(q => q.QuestionText)
                .NotEmpty()
                .MaximumLength(150);

            RuleForEach(q => q.Answers).SetValidator(new AnswerValidator());
        }
    }
}
