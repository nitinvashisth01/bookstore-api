using BookStore.Service.AuthorOperations;
using BookStore.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace BookStore.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : BaseController
    {
        #region Class Members

        private readonly IAuthorService _authorService;
        #endregion

        #region Constructor

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        #endregion

        #region End points

        [HttpGet]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns Authors List", typeof(IList<AuthorDto>))]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAll();

            return Ok(authors);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return newly created author", typeof(AuthorDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error", typeof(ErrorDto))]
        public IActionResult CreateAuthor([FromBody] AuthorDto authorDto)
        {
            var author = _authorService.Create(authorDto);
            return Ok(author);
        }

        #endregion
    }
}
