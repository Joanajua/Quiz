using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz1.Data;
using Quiz1.Models;

namespace Quiz1.Services
{
    public interface IQuizService
    {
        bool CreateQuiz(Quiz quiz);
        Task<IEnumerable<Quiz>> ListQuizzes();

    }
}
