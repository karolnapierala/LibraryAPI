using libraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace libraryAPI.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _libraryService.GetAll();

            return Ok(books);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetById([FromRoute] int id)
        {
            var book = _libraryService.GetById(id);

            return Ok(book);
        }
        [HttpGet("search/{title}")]
        public ActionResult<IEnumerable<Book>> GetByTitle([FromRoute] string title)
        {
            var books = _libraryService.GetByTitle(title);

            return Ok(books);
        }
        [HttpPost]
        public ActionResult<IEnumerable<Book>> AddBook([FromBody] Book book)
        {
            var id = _libraryService.Create(book);

            return Created($"/books/{id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Book>> Update([FromRoute] int id, [FromBody] Book book)
        {
            _libraryService.Update(id, book);

            return Created($"/books/{id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _libraryService.Delete(id);

            return NotFound();
        }
    }
}