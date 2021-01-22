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

        public bool QuizExists(string title)
        {
            return _context.Quizzes.Any(e => e.Title == title);
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
