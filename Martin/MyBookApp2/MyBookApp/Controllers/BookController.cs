using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookApp.Controllers;
using MyBookApp.Services;
using MyBookApp.Models;

namespace MyBookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{id}", Name = "GetBookById")]
        [ProducesResponseType(404)]
        public ActionResult<Book> Get(int id)
        {
            Book book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //PUT 
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

           // int nextId = _bookService.GetBooks().Max(b => b.BookId) + 1;
           // book.BookId = nextId;
            _bookService.AddBook(book);
            //return Ok(book);
            return CreatedAtRoute("GetBookById", new { id = book.BookId }, book);

        }
    }
}