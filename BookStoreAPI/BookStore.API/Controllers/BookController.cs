using BookStore.API.Filters;
using BookStore.Service.BookOperations;
using BookStore.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : BaseController
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
        [SwaggerResponse(StatusCodes.Status200OK, "Returns Books List", typeof(IList<BookDto>))]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns Book details", typeof(BookDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error", typeof(ErrorDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Error", typeof(ErrorDto))]
        public IActionResult GetBook([FromRoute] int bookId)
        {
            var books = _bookService.GetById(bookId);
            return Ok(books);
        }

        [HttpGet]
        [Route("bookTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns BookTypes List", typeof(IList<BookDto>))]
        public IActionResult GetBookTypes()
        {
            var bookTypes = _bookService.GetBookTypes();

            return Ok(bookTypes);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return newly created book", typeof(BookDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error", typeof(ErrorDto))]
        public IActionResult CreateBook([FromBody] BookDto bookDto)
        {
            var book = _bookService.Create(bookDto);
            return Ok(book);
        }

        #endregion
    }
}
