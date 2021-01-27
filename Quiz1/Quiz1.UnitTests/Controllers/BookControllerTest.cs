using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheBookLounge.DataAccess;
using TheBookLounge.DataAccess.Models;
using TheBookLounge.Web.Controllers;
using TheBookLounge.Web.Helpers;
using Xunit;

namespace TheBookLounge.UnitTests.Controllers
{
    public class BookControllerTest
    {
        private ApplicationDbContext _testDbContext;
        private BookController _controller;

        [Fact]
        public async Task List_action_result_get_method_should_return_ViewResult_with_correct_Model_type()
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new ApplicationDbContext(Utilities.Utilities.TestDbContextOptions()))
            {
                // Arrange
                _controller = new BookController(_testDbContext);
                var model = GetTestBooks();

                // Act
                var result = await _controller.List();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.IsAssignableFrom<IEnumerable<Book>>(viewResult.ViewData.Model);
                Assert.Equal(4, model.Count());
            }
        }

        [Theory]
        [InlineData("Book 1", "Book 1")]
        public async Task List_action_result_post_method_should_return_correct_ViewResult(string searchString, string expectedTempData)
        {
            // Initialising a testDbContext instance for each test scenario
            await using (_testDbContext = new ApplicationDbContext(Utilities.Utilities.TestDbContextOptions()))
            {
                // Arrange
                _controller = new BookController(_testDbContext);
                var httpContext = new DefaultHttpContext();
                var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

                // Act
                var result = await _controller.List(searchString);
                var resultTempData = _controller.TempData["search"];

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var data = viewResult.TempData["search"];
                Assert.IsType<ViewResult>(result);
                Assert.Equal(expectedTempData, resultTempData);
            }
        }

        private List<Book> GetTestBooks()
        {
            var books = new List<Book>
            {
                new Book()
                {
                    BookId = 1,
                    Title = "Book 1",
                    ISBN = "1111111111",
                    Genre = "Genre1",
                    TotalCopies = 1,
                    IsAvailable = true,
                    AuthorId = 1,
                },
                new Book()
                {
                    BookId = 2,
                    Title = "Book 2",
                    ISBN = "2-222222-22-2",
                    Genre = "Genre2",
                    TotalCopies = 1,
                    IsAvailable = true,
                    AuthorId = 2
                },
                new Book()
                {
                    BookId = 3,
                    Title = "Book 3",
                    ISBN = "9783333333333",
                    Genre = "Genre3",
                    TotalCopies = 1,
                    IsAvailable = true,
                    AuthorId = 3
                },
                new Book()
                {
                    BookId = 4,
                    Title = "Book 4",
                    ISBN = "978-4-44-444444-4",
                    Genre = "Genre4",
                    TotalCopies = 1,
                    IsAvailable = true,
                    AuthorId = 4
                }
            };

            return books;
        }

        private List<Author> GetTestAuthors()
        {
            var authors = new List<Author>
            {
                new Author()
                {
                    AuthorId = 1,
                    AuthorName = "Author 1"
                },
                new Author()
                {
                    AuthorId = 2,
                    AuthorName = "Author 2"
                },
                new Author()
                {
                    AuthorId = 3,
                    AuthorName = "Author 3"
                },
                new Author()
                {
                    AuthorId = 4,
                    AuthorName = "Author 4"
                }
            };
                
            return authors;
        }
    }
}
