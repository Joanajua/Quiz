using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using TheBookLounge.Web.Controllers;

namespace TheBookLounge.UnitTests.Controllers
{
    

    public class HomeControllerTest
    {
        private readonly Mock<ILogger<HomeController>> _mockLogger;
        // Arrange
        private readonly HomeController _controller;

        public HomeControllerTest()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_mockLogger.Object);
        }

        [Fact]
        public void Index_action_result_method_should_return_ViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_action_should_be_decorated_with_AllowAnonymous_attribute()
        {
            var type = _controller.GetType();
            var methodInfo = type.GetMethod("Index");
            var attributes = methodInfo?.GetCustomAttributes(typeof(AllowAnonymousAttribute), true);
            Assert.Equal(typeof(AllowAnonymousAttribute), attributes?[0].GetType());
        }
    }
}
