using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;

namespace Quiz1.Data
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Question>> GetAll()
        //{
        //    return await _context.Questions.ToListAsync();
        //}

        //public async Task<Question> GetByQuizId (int? quizId)
        //{
        //    return await _context.Questions
        //        .FirstOrDefaultAsync(q=> q.QuizId == quizId);
        //}

        //public async Task<IEnumerable<Question>> GetAllByQuizId( int? quizId)
        //{
        //    return await _context.Questions
        //        .Where(q => q.QuestionId == quizId)
        //        .OrderBy(q=>q.QuestionId)
        //        .ToListAsync();
        //}

        public IEnumerable<Question> GetAllByQuizId(int? quizId)
        {
            return  _context.Questions
                .Where(q => q.QuizId == quizId)
                .OrderBy(q => q.QuestionId)
                .ToList();
        }

        // Not sure Save and Edit are needed for Questions
        public void Save(Question question) => _context.Questions.Add(question);
        public void Edit(Question question) => _context.Questions.Update(question);
        public void Remove(Question question) => _context.Questions.Remove(question);

    }
}
