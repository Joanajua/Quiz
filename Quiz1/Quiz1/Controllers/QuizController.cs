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
        /// /List
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var quizzes = await _quizRepository.GetAll();

                // TODO - can take out a search method - ProcessSearchString()


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
                //model.CreateViewModelOnServerValidator(ModelState);

                // Validate input has been added to all questions
                if (model.Questions.Count != QuizConstants.NumQuestions)
                {
                    ModelState.AddModelError(string.Empty, "All the question fields need to be completed.");
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

                    if (string.IsNullOrWhiteSpace(question.QuestionText))
                    {
                        ModelState.AddModelError(string.Empty, "All the question fields need to be completed.");
                        return View(model);
                    }

                    if (question.Answers.Count != QuizConstants.NumAnswers)
                    {
                        ModelState.AddModelError(string.Empty, "All the answer fields need to be completed.");
                        return View(model);
                    }

                    var numCheckBoxes = 0;

                    foreach (var answer in question.Answers)
                    {
                        if (string.IsNullOrWhiteSpace(answer.AnswerText))
                        {
                            ModelState.AddModelError(string.Empty, "All the answer fields need to be completed.");
                            return View(model);
                        }
                        if (answer.IsCorrect)
                        {
                            numCheckBoxes++;
                        }
                    }

                    if (numCheckBoxes != 1)
                    {
                        ModelState.AddModelError(string.Empty, "Each Question needs to have at least 1 and only 1 answer selected as correct.");
                        return View(model);
                    }

                    questions.Add(newQuestion);
                }

                // TODO - VALIDATE LENGTH OF QUIZ'S TITLE, QUESTIONS AND ANSWERS
                // TODO - MAYBE CHECK IF USER HAS THE RIGHT ROLE TO MODIFY DB

                var newQuiz = new Quiz
                {
                    Title = model.Title,
                    Questions = questions
                };

                // Checking a quiz with same Title does not exist in db
                //var quiz = await _quizRepository.GetQuizByTitle(newQuiz.Title);

                //if (quiz != null)
                //{
                //    ModelState.AddModelError(string.Empty, "A quiz with the same title already exist in the system.");
                //    return View(model);
                //}

                // Checking if a quiz with same Title exists in the db
                if (_quizRepository.QuizExists(newQuiz.Title))
                {
                    ModelState.AddModelError(string.Empty, "A quiz with the same title already exist in the system.");
                    return View(model);
                }

                _quizRepository.Save(newQuiz);

                await _context.SaveChangesAsync();

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

            return View("Create", model);

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
