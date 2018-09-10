using Microsoft.AspNetCore.Mvc;
using MyBooksApp.Models;
using MyBooksApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_booksService.GetBooks());
        }

        [HttpGet("{id}", Name ="GetBookById")]
        [ProducesResponseType(404)]
        public ActionResult<Book> Get(int id)
        {
            Book book = _booksService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            int nextId = _booksService.GetBooks().Max(b => b.BookId) + 1;
            book.BookId = nextId;
            _booksService.AddBook(book);
            return CreatedAtRoute("GetBookById", new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            if (book == null || id != book.BookId)
                return BadRequest();

            Book orig = _booksService.GetBookById(id);
            if (orig == null)
                return NotFound();

            _booksService.UpdateBook(book);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Book orig = _booksService.GetBookById(id);
            if (orig != null)
            {
                _booksService.DeleteBook(orig);
            }
            return Ok();
        }
    }
}
