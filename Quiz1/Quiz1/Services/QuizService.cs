using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quiz1.Data;
using Quiz1.Models;

namespace Quiz1.Services
{
    public class QuizService : IQuizService
    {
        private ModelStateDictionary _modelState;
        private readonly IQuizRepository _quizRepository;

        public QuizService(ModelStateDictionary modelState, IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
            _modelState = modelState;
        }

        public async Task<IEnumerable<Quiz>> ListQuizzes()
        {
            return await _quizRepository.GetAllQuizzes();
        }
        public bool CreateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }

       
    }
}
