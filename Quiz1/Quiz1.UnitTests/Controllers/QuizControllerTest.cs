using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Quiz1.UnitTests.Utilities;
using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Controllers;
using Quiz1.ViewModels.QuizViewModels;
using Xunit;

namespace Quiz1.UnitTests.Controllers
{
    public class QuizControllerTest
    {
        private AppDbContext _testDbContext;
        private readonly SeedTestData _testData = new SeedTestData();
        private readonly Mock<IQuizRepository> _quizRepository = new Mock<IQuizRepository>();
        private readonly Mock<IQuestionRepository> _questionRepository = new Mock<IQuestionRepository>();
        private readonly Mock<IAnswerRepository> _answerRepository = new Mock<IAnswerRepository>();

        public QuizControllerTest()
        {
        }

    [Fact]
        public async Task Index_action_result_get_method_should_return_ViewResult_with_correct_Model_type()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                _quizRepository.Setup(repo => repo.GetAll()).ReturnsAsync(_testData.GetTestQuizzes);
                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Quiz>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
            }
        }

        [Fact]
        public void Index_action_result_should_be_decorated_with_AllowAnonymous_attribute()
        {
            var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Index");
            var attributes = methodInfo?.GetCustomAttributes(typeof(AllowAnonymousAttribute), true);
            Assert.Equal(typeof(AllowAnonymousAttribute), attributes?[0].GetType());
        }

        [Theory]
        [InlineData("Quiz 1", "Quiz 1")]
        public async Task Search_action_result_post_method_should_return_correct_ViewResult(string searchString, string expectedTempData)
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                _quizRepository.Setup(repo => repo.GetAll()).ReturnsAsync(_testData.GetTestQuizzes);

                var httpContext = new DefaultHttpContext();

                var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>())
                {
                    ["search"] = searchString
                };

                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext)
                {
                    TempData = tempData
                };

                // Act
                var result = await controller.Search(searchString);
                var resultTempData = controller.TempData["search"];

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.IsType<ViewResult>(result);

                Assert.Equal(expectedTempData, resultTempData);

                var model = Assert.IsAssignableFrom<IEnumerable<Quiz>>(viewResult.ViewData.Model);
                Assert.All(model, q=>q.Title = expectedTempData);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task Search_action_result_post_redirect_to_action_Index_result_get_when_searchString_null_or_empty(string searchString)
        {
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                _quizRepository.Setup(repo => repo.GetAll()).ReturnsAsync(_testData.GetTestQuizzes);

                var httpContext = new DefaultHttpContext();

                var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext)
                {
                    TempData = tempData
                };

                // Act
                var result = await controller.Search(searchString);

                // Assert
                Assert.IsType<RedirectToActionResult>(result);
            }
        }

        [Fact]
        public void Search_action_result_should_be_decorated_with_AllowAnonymous_attribute()
        {
            var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Index");
            var attributes = methodInfo?.GetCustomAttributes(typeof(AllowAnonymousAttribute), true);
            Assert.Equal(typeof(AllowAnonymousAttribute), attributes?[0].GetType());
        }

        [Theory]
        [InlineData("Quiz 1", false, 0)]
        [InlineData("1Quiz", false, 0)]
        [InlineData("1", true, 1)]
        [InlineData("0", true, 0)]
        public void SearchForQuiz_should_parse_only_int_values(string searchString, bool expectedIsStringParsed, int expectedOutIntValue)
        {
            // Act
            var result = int.TryParse(searchString, out int stringParsed);

            Assert.Equal(result, expectedIsStringParsed);
            Assert.Equal(stringParsed, expectedOutIntValue);
        }

        [Fact]
        public async Task Details_action_result_method_should_return_ViewResult_with_correct_Model_type()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                var id = 1;
                var expectedQuiz = _testData.GetTestQuizzes().FirstOrDefault(q=> q.QuizId == id);

                _quizRepository.Setup(repo => repo.GetQuizById(id)).ReturnsAsync(expectedQuiz);

                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = await controller.Details(id);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<DetailsViewModel>(viewResult.ViewData.Model);
                Assert.NotNull(result);
                Assert.Equal(expectedQuiz.QuizId, model.Quiz.QuizId);
            }
        }

        [Fact]
        public async Task Details_action_result_method_should_return_BadRequest_when_id_is_null()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = await controller.Details(null);

                // Assert
                var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
                var model = Assert.IsAssignableFrom<BadRequestObjectResult>(badRequestObjectResult);
                Assert.Equal(model.StatusCode, badRequestObjectResult.StatusCode);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task Details_action_result_method_should_return_NotFound_when_server_returns_no_quizzes()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                var id = 0;
                var expectedQuiz = _testData.GetTestQuizzes().FirstOrDefault(q => q.QuizId == id);

                _quizRepository.Setup(repo => repo.GetQuizById(id)).ReturnsAsync(expectedQuiz);
                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = await controller.Details(id);

                // Assert
                var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
                var model = Assert.IsAssignableFrom<NotFoundObjectResult>(notFoundObjectResult);
                Assert.Equal(model.StatusCode, notFoundObjectResult.StatusCode);
                Assert.Equal(model.Value, notFoundObjectResult.Value);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task Details_action_result_method_should_return_NotFound_when_server_returns_no_questions()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                var id = 0;
                var expectedQuestions = _testData.GetTestQuestions().Where(q => q.QuizId == id);

                _questionRepository.Setup(repo => repo.GetAllByQuizId(id)).Returns(expectedQuestions);
                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = await controller.Details(id);

                // Assert
                var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
                var model = Assert.IsAssignableFrom<NotFoundObjectResult>(notFoundObjectResult);
                Assert.Equal(model.StatusCode, notFoundObjectResult.StatusCode);
                Assert.Equal(model.Value, notFoundObjectResult.Value);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task Details_action_result_method_should_return_NotFound_when_server_returns_no_answers()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                var id = 0;
                var expectedAnswers = _testData.GetTestAnswers().Where(q => q.QuestionId == id);

                _answerRepository.Setup(repo => repo.GetAllByQuestionId(id)).Returns(expectedAnswers);
                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = await controller.Details(id);

                // Assert
                var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
                var model = Assert.IsAssignableFrom<NotFoundObjectResult>(notFoundObjectResult);
                Assert.Equal(model.StatusCode, notFoundObjectResult.StatusCode);
                Assert.Equal(model.Value, notFoundObjectResult.Value);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void Details_action_result_should_be_decorated_with_AllowAnonymous_attribute()
        {
            var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Details");
            var attributes = methodInfo?.GetCustomAttributes(typeof(AllowAnonymousAttribute), true);
            Assert.Equal(typeof(AllowAnonymousAttribute), attributes?[0].GetType());
        }

        [Fact]
        public void SubmitNew_action_result_should_return_ViewResult_with_correct_Model_type()
        {
            // Initialising a testDbContext instance for each test scenario
            using (_testDbContext = new AppDbContext(TestDbContextOptions.GetTestDbContextOptions()))
            {
                // Arrange
                _quizRepository.Setup(repo => repo.GetAll()).ReturnsAsync(_testData.GetTestQuizzes);
                var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);

                // Act
                var result = controller.Create();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<CreateViewModel>(viewResult.ViewData.Model);
                Assert.NotNull(result);

                Assert.Null(model.Title);

                Assert.IsType<List<Question>>(model.Questions);
                Assert.NotEmpty(model.Questions);
                Assert.All(model.Questions, q => q.QuestionText.IsNullOrEmpty());

                Assert.All(model.Questions, q => q.Answers.ForEach(a=>a.AnswerText.IsNullOrEmpty()));
                Assert.All(model.Questions, q => q.Answers.ForEach(a => a.IsCorrect.Equals(false)));

                Assert.IsType<List<string>>(model.Errors);
                Assert.Empty(model.Errors);

            }
        }

        [Fact]
        public void SubmitNew_action_result_get_method_should_be_decorated_with_AllowAnonymous_attribute()
        {
            var controller = new QuizController(_quizRepository.Object, _questionRepository.Object, _answerRepository.Object, _testDbContext);
            var type = controller.GetType();
            var methodInfo = type.GetMethod("Create");
            var attributes = methodInfo?.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            Assert.Equal(typeof(AuthorizeAttribute), attributes?[0].GetType());
        }
    }
}
