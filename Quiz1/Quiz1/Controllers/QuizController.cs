using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;
using Quiz1.ViewModels;

namespace Quiz1.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Quiz
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quizzes.ToListAsync());
        }

        // GET: Quiz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.QuizId == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // GET: Quiz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quiz);
        }

        // GET: Quiz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        // POST: Quiz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title")] Quiz quiz)
        {
            if (id != quiz.QuizId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.QuizId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quiz);
        }

        // GET: Quiz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.QuizId == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Quiz/Play/5
        public async Task<IActionResult> Play(int? id)
        {
            List<Answer> answersToReturn = new List<Answer>();

            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.QuizId == id);

            var questions =  await _context.Questions
                .Where(m => m.QuizId == id).ToListAsync();

            //IQueryable<Answer> answers;
            if (quiz == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers.ToListAsync();

            foreach (var question in questions)
            {
                if (answersToReturn.Count > 0)
                {
                    answersToReturn.Clear();
                }
                
                var filteredAnswers = answers.Where(a=> a.QuestionId == question.QuestionId).ToList();
                
                foreach (var answer in filteredAnswers)
                {
                    
                    if (question.QuestionId == answer.QuestionId)
                    {
                        answersToReturn.Add(answer);
                    }
                }

            }

            var model = new PlayViewModel
            {
                Quiz = quiz,
                Questions = questions,
                ////Answers = answersToReturn
            };

            return View(model);





            //var answersByQuestionDicc = new Dictionary<int, List<Answer>>();

            //foreach (var question in questions)
            //{
            //    // Select the answers for each question
            //    var answersByQuestionList = answers.Where(a => a.QuestionId == question.QuestionId).ToList();
            //    answersByQuestionDicc.Add(question.QuestionId, answersByQuestionList);
            //}

            //var model = new PlayViewModel
            //{
            //    Quiz = quiz,
            //    Questions = questions,
            //    AnswersByQuestion = answersByQuestionDicc
            //};

        }

        private bool QuizExists(int id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }


    }
}
