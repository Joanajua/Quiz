using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Quiz1.Models;

namespace Quiz1.Data
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAllByQuestionId(int? questionId);

        Task<Answer> GetByQuestionId(int? questionId);

        void Save(Answer answer);
        void Edit(Answer answer);
        void Remove(Answer answer);
    }
}
