using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Microsoft.Extensions.Logging;
using Quiz1.UnitTests.Utilities;
using Quiz1.Data;
using Quiz1.Models;
using Quiz1.Controllers;

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
    }
}
