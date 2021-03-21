using BookStore.Service.OrderOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Create New Order"
        )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            _orderService.Create(orderDto);
            return Ok();
        }

        #endregion
    }
}
