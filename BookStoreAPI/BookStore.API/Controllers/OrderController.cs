using BookStore.Service.OrderOperations;
using BookStore.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : BaseController
    {
        #region Class Members

        private readonly IOrderService _orderService;
        #endregion

        #region Constructor

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        #region End points

        [HttpPost]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error", typeof(ErrorDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Error", typeof(ErrorDto))]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            await _orderService.Create(orderDto);
            return Ok();
        }

        #endregion
    }
}
