using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Quiz1.Models;

namespace Quiz1.Data
{
    public interface IQuestionRepository
    {
        //Task<IEnumerable<Question>> GetAllByQuizId(int? quizId);

        IEnumerable<Question> GetAllByQuizId(int? quizId);


        void Save(Question question);
        void Edit(Question question);
        void Remove(Question question);
    }
}
