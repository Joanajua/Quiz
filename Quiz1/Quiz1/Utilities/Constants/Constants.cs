using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Quiz1.Utilities.Constants
{
    public class QuizConstants
    {
        public const int NumQuestions = 3;
        public const int NumAnswers = 4;
    }

    public class ErrorMessages
    {
        public const string BadRequest = "Bad Request. There was no id selected, please go back to the page and select a quiz.";
        public const string NotFound = "Not found quizzes with the selected id does not exist.";
        public const string NotFoundQuestion = "Not found questions for the selected id.";
        public const string NotFoundAnswer = "Not found answers for the selected id.";
    }
}
