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


        public IEnumerable<Question> GetAllByQuizId(int? quizId)
        {
            return  _context.Questions
                .Where(q => q.QuizId == quizId)
                .OrderBy(q => q.QuestionId)
                .ToList();
        }

        public void Save(Question question) => _context.Questions.Add(question);
        public void Edit(Question question) => _context.Questions.Update(question);
        public void Remove(Question question) => _context.Questions.Remove(question);

    }
}
