﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Quiz1.Models;

namespace Quiz1.Data
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAll();

        Task<Quiz> GetById(int? quizId);

        bool QuizExists(int id);
        bool QuizExists(string title);

        void Save(Quiz quiz);
        void Edit(Quiz quiz);
        void Remove(Quiz quiz);
    }
}
