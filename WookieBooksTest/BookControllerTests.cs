using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WookieBooks.Controllers;
using WookieBooks.Models;
using WookieBooks.Repository;

namespace WookieBooksTest
{
    [TestClass]
    public class BookControllerTests
    {   
        [TestMethod]
        public void TestGetBooks()
        {
            ILogger<BookController> logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BookController>();
            var controller = new BookController(logger, new BookRepository());
            var response = controller.Get(1, 10);                
            var okResult = response as OkObjectResult;            
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public void TestGetBook()
        {
            ILogger<BookController> logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BookController>();
            var controller = new BookController(logger, new BookRepository());
            var response = controller.Get(1);
            var okResult = response as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task TestCreateBook()
        {
            ILogger<BookController> logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BookController>();
            var controller = new BookController(logger, new BookRepository());
            var response = controller.Create(new Book()
            {
                Title = "Test Book",
                Description = "Test Desciption",
                Author = "Test Author",
                CoverImage = "",
                Price = 0m
            });
            var okResult = await response as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task TestUpdateBook()
        {
            ILogger<BookController> logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BookController>();
            var controller = new BookController(logger, new BookRepository());
            var response = controller.Update(new Book()
            {
                ID = 1,
                Price = 19.99m
            });
            var okResult = await response as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task TestDeleteBook()
        {
            ILogger<BookController> logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<BookController>();
            var controller = new BookController(logger, new BookRepository());
            var response = controller.Update(new Book()
            {
                ID = 1                
            });
            var okResult = await response as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}