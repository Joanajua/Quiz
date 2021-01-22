using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quiz1.Models;
using Quiz1.Utilities.Constants;
using Quiz1.ViewModels.QuizViewModels;

namespace Quiz1.Validators
{
    public static class ServerValidator
    {
        //public static CreateViewModelOnServerValidator (this CreateViewModel model, ModelStateDictionary modelState)
        //{
        //    // results will contain all the failed validation errors.
        //    if (model.Questions.Count != QuizConstants.NumQuestions)
        //    {
        //        modelState.AddModelError(string.Empty, "All the question fields need to be completed.");
        //        return View(model);
        //    }
            
        //    // Validate input has been added to all questions
            

        //    foreach (var question in model.Questions)
        //    {
        //        if (string.IsNullOrWhiteSpace(question.QuestionText))
        //        {
        //            modelState.AddModelError(string.Empty, "All the question fields need to be completed.");
        //            return false;

        //        }

        //        if (question.Answers.Count != QuizConstants.NumAnswers)
        //        {
        //            modelState.AddModelError(string.Empty, "All the answer fields need to be completed.");
        //            return false;
        //        }

        //        var numCheckBoxes = 0;

        //        foreach (var answer in question.Answers)
        //        {
        //            if (string.IsNullOrWhiteSpace(answer.AnswerText))
        //            {
        //                modelState.AddModelError(string.Empty, "All the answer fields need to be completed.");
        //                return false;
        //            }

        //            if (answer.IsCorrect)
        //            {
        //                numCheckBoxes++;
        //            }
        //        }

        //        if (numCheckBoxes != 1)
        //        {
        //            modelState.AddModelError(string.Empty, "Each Question needs to have at least 1 and only 1 answer selected as correct.");
        //            return false;

        //        }
        //    }

        //    return true;
        //}
    }
}
