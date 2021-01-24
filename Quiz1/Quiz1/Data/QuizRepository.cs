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

        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz> GetQuizById (int? quizId)
        {
            return await _context.Quizzes
                .FirstOrDefaultAsync(q=> q.QuizId == quizId);
        }

        public bool QuizExists(Quiz quiz)
        {
            // Needs to return true just when title is of a quiz with different id
            // if id is the same means the quiz is being updated.
            return _context.Quizzes.Any(e => e.Title == quiz.Title && e.QuizId != quiz.QuizId);
        }

        public bool QuizExists(int id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }

        public void Save(Quiz quiz) => _context.Quizzes.Add(quiz);
        public void Edit(Quiz quiz) => _context.Quizzes.Update(quiz);
        public void Remove(Quiz quiz) => _context.Quizzes.Remove(quiz);

    }
}
