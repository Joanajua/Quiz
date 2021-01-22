using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;

namespace Quiz1.Data
{
    public class AnswerRepository: IAnswerRepository
    {
        private readonly AppDbContext _context;

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAllByQuestionId( int? questionId)
        {
            return _context.Answers
                .Where(q => q.QuestionId == questionId)
                .ToList();
        }

        public async Task<Answer> GetByQuestionId(int? questionId)
        {
            return await _context.Answers
                .FirstOrDefaultAsync(q => q.QuestionId == questionId);
        }

        // Not sure Save and Edit are needed for Questions
        public void Save(Answer answer) => _context.Answers.Add(answer);
        public void Edit(Answer answer) => _context.Answers.Update(answer);
        public void Remove(Answer answer) => _context.Answers.Remove(answer);

    }
}
