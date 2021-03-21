using BookStore.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ServiceFilter(typeof(CustomExceptionFilter), Order = 1)]
    public class BaseController : ControllerBase
    {
    }
}
