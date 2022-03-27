using Microsoft.AspNetCore.Mvc;
using WookieBooks.Interfaces;
using WookieBooks.Models;
using WookieBooks.Repository;

namespace WookieBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {        
        private readonly ILogger<BookController> _logger;        
        private readonly IBookRepository _bookRepository;

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {            
            _logger = logger;
            _bookRepository = bookRepository;

            // seed in memory database with default values 
            DefaultData.Initaialize(_bookRepository);            
        }
     
        [HttpGet("~/books/all")]
        public IActionResult Get(int page, int count)
        {
            try
            {
                List<Book> books = _bookRepository.Get(page, count);
                if (books.Count > 0)
                {
                    return Ok(books);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BookController.Get. {e.Message} /r/n{Environment.StackTrace}");
            }
            return NotFound();
        }
    
     
        [HttpGet("~/books/read")]
        public ActionResult Get(int id)
        {
            try
            {
                Book? book = _bookRepository.Get(id);
                if (book != null)
                {
                    return Ok(book);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BookController.Get. {e.Message} /r/n{Environment.StackTrace}");
            }
            return NotFound();
        }
  
        [HttpPost("~/books/create")]
        public async Task<IActionResult> Create(Book book)
        {
            try
            {
                Book? createdBook = await _bookRepository.Create(book);
                if (createdBook != null)
                {
                    return Ok(createdBook);
                }
            }            
            catch (Exception e)
            {
                _logger.LogError($"Error in BookController.Create. {e.Message} /r/n{Environment.StackTrace}");                
            }
            return NotFound();
        }
  
        [HttpPut("~/books/update")]
        public async Task<IActionResult> Update(Book book)
        {
            try
            {
                Book? updatedBook = await _bookRepository.Update(book);
                if (updatedBook != null)
                {
                    return Ok(updatedBook);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BookController.Update. {e.Message} /r/n{Environment.StackTrace}");
            }
            return NotFound();
        }

        [HttpDelete("~/books/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _bookRepository.Delete(id))
                {
                    return Ok();
                }                
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in BookController.Delete. {e.Message} /r/n{Environment.StackTrace}");
            }
            return NotFound();
        }
    }
}
