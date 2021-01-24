using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Utilities.CustomExtensions;
using Quiz1.Utilities.Constants;
using Quiz1.Validators;
using Quiz1.ViewModels.QuizViewModels;

namespace Quiz1.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        private readonly AppDbContext _context;

        public QuizController(IQuizRepository quizRepository, IQuestionRepository questionRepository,
            IAnswerRepository answerRepository, AppDbContext context)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _context = context;
        }

        // GET: Quiz
        /// <summary>
        /// Shows the list of all the quizzes
        /// </summary>
        /// <returns>Quiz/Index</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _quizRepository.GetAll());
        }

        /// <summary>
        /// Gets a list quizzes
        /// depending if there is an input in the search box.
        /// The user can look for quizzes on the search box by
        /// Title or Quiz Id
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>
        /// Quiz/Index/searchString
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var quizzes = await _quizRepository.GetAll();

                quizzes = SearchForQuiz(searchString, quizzes);

                TempData["search"] = searchString;

                return View(quizzes);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Search throw a given list of quizzes for a string or an id
        /// Tries to parse the string into an id
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="quizzes"></param>
        /// <returns>A list of quizzes</returns>
        private static IEnumerable<Quiz> SearchForQuiz(string searchString, IEnumerable<Quiz> quizzes)
        {
            if (int.TryParse(searchString, out int stringParsed))
            {
                // Search by Quiz Id
                quizzes = quizzes.Where(s => s.QuizId.Equals(stringParsed)).ToList();
            }
            else
            {
                // Search by Quiz Title
                // The search is NOT case sensitive.
                quizzes = quizzes.Where(s => s.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return quizzes;
        }

        /// GET: Quiz/Details/5
        /// <summary>
        /// Shows the details of a quiz by a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Quiz/Details/id</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _quizRepository.GetQuizById(id);

            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
            }

            var questions = _questionRepository.GetAllByQuizId(id);

            if (questions == null)
            {
                return NotFound($"There are no questions for Quiz id {id}.");
            }

            var answers = new List<Answer>();

            foreach (var question in questions)
            {
                answers = _answerRepository.GetAllByQuestionId(question.QuestionId) as List<Answer>;

                question.Answers = answers;
            }

            var model = new DetailsViewModel
            {
                Quiz = quiz,
                Questions = questions,
            };

            return View(model);
        }

        /// <summary>
        /// Shows the Create view with an empty form
        /// </summary>
        /// <returns>Quiz/Create</returns>
        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        // POST: Quiz/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            var serverValidation = new ServerValidation(_quizRepository);

            if (ModelState.IsValid)
            {
                var quiz = new Quiz
                {
                    Title = model.Title,
                    Questions = model.Questions
                };

                // A second validation on top of the client-side validation
                // It makes sure the inputs the client-side validation covers are correct
                // and performs other validation that is not executed in the client-side
                var isModelValidInServer = serverValidation.IsModelValidInServer(quiz, ModelState);

                if (isModelValidInServer)
                {
                    _quizRepository.Save(quiz);

                    await _context.SaveChangesAsync();

                    // Passing which page the user comes from
                    // It is to difference the message coming from the Edit page
                    TempData["create"] = "Create";

                    return RedirectToAction("Details", new { id = quiz.QuizId });
                }

                serverValidation.AddModelStateErrorsOnCreate(model, ModelState);

                return View(model);
            }

            serverValidation.AddModelStateErrorsOnCreate(model, ModelState);

            return View(model);
        }

        // GET: Quiz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _quizRepository.GetQuizById(id);

            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
            }

            quiz.Questions = _questionRepository.GetAllByQuizId(id) as List<Question>;

            if (quiz.Questions == null)
            {
                return NotFound($"There are no questions for Quiz with id {id}.");
            }

            foreach (var question in quiz.Questions)
            {
                question.Answers = _answerRepository.GetAllByQuestionId(question.QuestionId) as List<Answer>;
            }

            return View(quiz);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Quiz quiz)
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
                    if (!_quizRepository.QuizExists(quiz.QuizId))
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

            var quiz = await _quizRepository.GetQuizById(id);

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
            var quiz = await _quizRepository.GetQuizById(id);

            var questions = _questionRepository.GetAllByQuizId(id);

            foreach (var question in questions)
            {
                var answers = _answerRepository.GetAllByQuestionId(question.QuestionId);

                foreach (var answer in answers)
                {
                    _answerRepository.Remove(answer);
                }

                _questionRepository.Remove(question);
            }

            _quizRepository.Remove(quiz);

            await _context.SaveChangesAsync();

            TempData["message-delete"] = $"The Quiz with id = {id} has been successfully deleted from the system.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Quiz/Play/5
        public async Task<IActionResult> Play(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            var quiz = await _quizRepository.GetQuizById(id);

            if (quiz == null)
            {
                return NotFound($"Quiz id {id} does not exist.");
            }

            var questions = _questionRepository.GetAllByQuizId(id);

            if (questions == null)
            {
                return NotFound($"There are no questions for Quiz id {id}.");
            }

            //var answers = await _context.Answers.ToListAsync();

            foreach (var question in questions)
            {
                question.Answers = new List<Answer>();

                question.Answers = _answerRepository.GetAllByQuestionId(question.QuestionId) as List<Answer>;

                // Applying extension method to produce random list
                question.Answers.Shuffle();

            }

            var model = new PlayViewModel
            {
                Quiz = quiz,
                Questions = questions,
            };

            return View(model);
        }
    }
}
