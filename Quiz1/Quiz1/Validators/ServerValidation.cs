using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Utilities.Constants;
using Quiz1.ViewModels.QuizViewModels;

namespace Quiz1.Validators
{
    public class ServerValidation
    {
        private IQuizRepository _quizRepository;

        public ServerValidation(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        // Checks if a quiz with same Title exists in the db
        public bool IsModelValidInServer(Quiz quiz, ModelStateDictionary modelState)
        {
            // TODO - CHECK IF USER HAS THE RIGHT ROLE TO MODIFY DB

            if (_quizRepository.QuizExists(quiz))
            {
                modelState.AddModelError(string.Empty, "A quiz with the same title already exist in the system.");
                return false;
            }

            if (quiz.Title.Length > 100)
            {
                modelState.AddModelError(string.Empty, "A quiz's title cannot exceed 100 characters.");
                return false;
            }

            if (quiz.Questions.Count != QuizConstants.NumQuestions)
            {
                modelState.AddModelError(string.Empty, "All the question fields need to be completed.");
                return false;
            }

            foreach (var question in quiz.Questions)
            {
                if (string.IsNullOrWhiteSpace(question.QuestionText))
                {
                    modelState.AddModelError(string.Empty, "All the question fields need to be completed.");
                    return false;
                }

                if (question.QuestionText.Length > 150)
                {
                    modelState.AddModelError(string.Empty, "The question's text cannot exceed 150 characters.");
                    return false;
                }

                if (question.Answers.Count != QuizConstants.NumAnswers)
                {
                    modelState.AddModelError(string.Empty, "All the answer fields need to be completed.");
                    return false;
                }

                var numCheckBoxes = 0;

                foreach (var answer in question.Answers)
                {
                    if (string.IsNullOrWhiteSpace(answer.AnswerText))
                    {
                        modelState.AddModelError(string.Empty, "All the answer fields need to be completed.");
                        return false;
                    }

                    if (answer.AnswerText.Length > 150)
                    {
                        modelState.AddModelError(string.Empty, "The answer's text cannot exceed 150 characters.");
                        return false;
                    }

                    if (answer.IsCorrect)
                    {
                        numCheckBoxes++;
                    }
                }

                if (numCheckBoxes != 1)
                {
                    modelState.AddModelError(string.Empty, "Each Question needs to have at least 1 and only 1 answer selected as correct.");
                    return false;
                }
            }

            return true;
        }
    }
}
