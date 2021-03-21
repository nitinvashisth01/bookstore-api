using BookStore.Service.BookOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("books")]
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
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        #endregion
    }
}
