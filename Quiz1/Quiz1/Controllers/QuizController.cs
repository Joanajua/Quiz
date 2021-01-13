using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;
using Quiz1.Utilities.CustomExtensions;
using Quiz1.ViewModels.QuizViewModels;

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

        /// <summary>
        /// Gets a list quizzes
        /// depending if there is an input in the search box.
        /// The user can look for quizzes on the search box by
        /// Title or Quiz Id
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>
        /// /List
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                IEnumerable<Quiz> quizzes = await _context.Quizzes
                    .ToListAsync();

                int stringResult = 0;

                if (int.TryParse(searchString, out stringResult))
                {
                    // Search by Quiz Id
                    quizzes = quizzes.Where(s => s.QuizId.Equals(stringResult));
                }
                // Search by Quiz Title
                // The search is NOT case sensitive.
                quizzes = quizzes.Where(s => s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase));

                TempData["search"] = searchString;

                return View(quizzes);
            }

            return RedirectToAction("Index");
        }

        // GET: Quiz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.QuizId == id);

            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
            }

            /////////////////////
            var questions = await _context.Questions
                .Where(m => m.QuizId == id)
                .OrderBy(q => q.QuestionId)
                .ToListAsync();

            if (questions == null)
            {
                return NotFound($"There are no questions for Quiz id {id}.");
            }

            var answers = await _context.Answers.ToListAsync();

            foreach (var question in questions)
            {
                question.Answers = new List<Answer>();

                var filteredAnswers = answers
                    .Where(a => a.QuestionId == question.QuestionId)
                    .OrderByDescending(a => a.IsCorrect)
                    .ToList();

                question.Answers = filteredAnswers;

            }

            var model = new DetailsViewModel
            {
                Quiz = quiz,
                Questions = questions,
            };

            return View(model);
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
                return BadRequest();
            }

            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
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
                return BadRequest();
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

            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.QuizId == id);

            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
            }

            var questions = await _context.Questions
                .Where(m => m.QuizId == id)
                .ToListAsync();

            if (questions == null)
            {
                return NotFound($"There are no questions for Quiz id {id}.");
            }

            var answers = await _context.Answers.ToListAsync();

            foreach (var question in questions)
            {
                question.Answers = new List<Answer>();

                //if (question.Answers.Count > 0)
                //{
                //    question.Answers.Clear();
                //}

                var filteredAnswers = answers.Where(a => a.QuestionId == question.QuestionId).ToList();

                // Applying extension method to produce random list
                filteredAnswers.Shuffle();

                question.Answers = filteredAnswers;

            }

            var model = new PlayViewModel
            {
                Quiz = quiz,
                Questions = questions,
            };

            return View(model);
        }

        private bool QuizExists(int id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }
    }
}
