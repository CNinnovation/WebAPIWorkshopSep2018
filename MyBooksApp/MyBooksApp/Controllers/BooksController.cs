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
    }
}
