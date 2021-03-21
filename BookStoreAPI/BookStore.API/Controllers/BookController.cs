using BookStore.Service.BookOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Class Members

        private readonly IBookService _bookService;
        #endregion

        #region Constructor

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #endregion

        #region End points

        [HttpGet]
        [Route("")]
        [SwaggerOperation(
            Summary = "Retrieves List of Books"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns Books List", typeof(IList<BookDto>))]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpPost]
        [Route("")]
        [SwaggerOperation(
            Summary = "Create New Book"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Return newly created book", typeof(BookDto))]
        public IActionResult CreateBook([FromBody] BookDto bookDto)
        {
            var book = _bookService.Create(bookDto);
            return Ok(book);
        }

        #endregion
    }
}
