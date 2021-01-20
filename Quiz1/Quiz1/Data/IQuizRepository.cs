using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz1.Models;

namespace Quiz1.Data
{
    interface IQuizRepository
    {
        IEnumerable<Quiz> GetAllQuizzes { get; }
        Quiz GetQuizById(int quizId);
        Quiz GetQuizByTitle(string quizTitle);

    }
}
