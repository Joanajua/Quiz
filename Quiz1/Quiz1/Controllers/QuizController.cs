using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;
using Quiz1.Utilities.CustomExtensions;
using Quiz1.Utilities.Constants;
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
                    quizzes = quizzes.Where(s => s.QuizId.Equals(stringResult)).ToList();
                }
                else
                {
                    // Search by Quiz Title
                    // The search is NOT case sensitive.
                    quizzes = quizzes.Where(s => s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase));
                }

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
            return View(new CreateViewModel());
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Questions.Count != QuizConstants.NumQuestions)
                {
                    ModelState.AddModelError(string.Empty, "The three question fields need to be completed.");
                    return View(model);
                }

                var questions = new List<Question>();
                foreach (var question in model.Questions)
                {
                    var newQuestion = new Question
                    {
                        QuestionText = question.QuestionText,
                        Answers = question.Answers
                    };

                    if (question.Answers.Count != QuizConstants.NumAnswers)
                    {
                        ModelState.AddModelError(string.Empty, "The four answer fields need to be completed.");
                        return View(model);
                    }

                    var numCheckBoxes = 0;

                    foreach (var answer in question.Answers)
                    {
                        if (answer.IsCorrect)
                        {
                            numCheckBoxes++;
                        }
                    }

                    if (numCheckBoxes != 1)
                    {
                        ModelState.AddModelError(string.Empty, "Each Question needs to have at least 1 and only 1 correct answer.");
                        return View(model);
                    }

                    questions.Add(newQuestion);
                }

                // TODO - VALIDATE QUIZ DOESN'T EXIST IN DB
                // TODO - MAYBE CHECK IF USER HAS THE RIGHT ROLE TO MODIFY DB

                var newQuiz = new Quiz
                {
                    Title = model.Title,
                    Questions = questions
                };

                var quiz = await _context.Quizzes.FirstOrDefaultAsync(q=> q.Title == newQuiz.Title);

                // Not sure about the following part
                if (quiz != null)
                {
                    ModelState.AddModelError(string.Empty, "A quiz with the same title already exist in the system.");
                    return View(model);
                }

                await _context.Quizzes.AddAsync(newQuiz);

                await _context.SaveChangesAsync();

                // Success message to pass to the Details page
                //TempData["message-create"] = "The new Quiz has been added successfully.";

                // Passing which page the user comes from
                // It is to difference the message coming from the Edit page
                TempData["create"] = "Create";

                return RedirectToAction("Details", new { id = newQuiz.QuizId });
            }

            foreach (var value in ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    model.Errors.Add(error.ErrorMessage);
                }
            }
            
            return RedirectToAction("Create", model);

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var questions = new List<Question>();
            //foreach (var questionModel in model.Questions)
            //{
            //    var question = new Question
            //    {
            //        QuestionText = questionModel.QuestionText,
            //        Answers = questionModel.Answers
            //    };

            //    questions.Add(question);
            //}

            //var quiz = new Quiz
            //{
            //    Title = model.Title,
            //    Questions = questions
            //};

            //await _context.Quizzes.AddAsync(quiz);

            //await _context.SaveChangesAsync();

            //// Success message to pass to the Details page
            //TempData["message-create"] = "The new Quiz has been added successfully.";

            //// Passing which page the user comes from
            //// It is to difference the message coming from the Edit page
            //TempData["create"] = "Create";

            //return RedirectToAction("Details", new{ id = quiz.QuizId});
        }

        // GET: Quiz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _context.Quizzes.FirstOrDefaultAsync(q=>q.QuizId == id);

            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
            }

            quiz.Questions = await _context.Questions.Where(qu => qu.QuizId == id).ToListAsync();

            foreach (var question in quiz.Questions)
            {
                question.Answers = await _context.Answers.Where(a => a.QuestionId == question.QuestionId).ToListAsync();
            }

            return View(quiz);
        }

        // POST: Quiz/Edit/5
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
