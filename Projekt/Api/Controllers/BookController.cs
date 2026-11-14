using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? title)
        {
            var books = _bookService.GetBooks(title);
            if (books.Count == 0)
                return NoContent();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateNewBookCommand command)
        {
            var result = _bookService.AddNewBook(command);
            if (!result.Success)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }
    }
}
