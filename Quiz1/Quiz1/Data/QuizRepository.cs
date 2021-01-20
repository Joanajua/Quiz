using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;

namespace Quiz1.Data
{
    public class QuizRepository: IQuizRepository
    {
        private readonly AppDbContext _context;

        public QuizRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Quiz> GetAllQuizzes => _context.Quizzes;
        
        public Quiz GetQuizById (int quizId)
        {
            return _context.Quizzes
                .FirstOrDefault(q=> q.QuizId == quizId);
        }

        public Quiz GetQuizByTitle (string quizTitle)
        {
            return _context.Quizzes
                .FirstOrDefault(q => q.Title == quizTitle);
        }
    }
}
