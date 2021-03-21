using System.Threading.Tasks;

namespace BookStore.Service.OrderOperations
{
    public interface IOrderService
    {
        Task Create(OrderDto orderDto);
    }
}
