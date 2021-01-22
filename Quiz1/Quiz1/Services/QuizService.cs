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
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public QuizService(ModelStateDictionary modelState, IQuizRepository quizRepository,
            IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _modelState = modelState;
        }

        //------> QUIZZES
        public async Task<IEnumerable<Quiz>> GetListQuizzes()
        {
            return await _quizRepository.GetAll();
        }

        public async Task<Quiz> GetQuizById(int? id)
        {
            return await _quizRepository.GetById(id);
        }

        public bool CreateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        //------> QUESTIONS
        public IEnumerable<Question> GetListQuestions(int? quizId)
        {
            return _questionRepository.GetAllByQuizId(quizId);
        }


        //------> ANSWERS
        public IEnumerable<Answer> GetListAnswers(int? questionId)
        {
            return _answerRepository.GetAllByQuestionId(questionId);
        }

    }
}
