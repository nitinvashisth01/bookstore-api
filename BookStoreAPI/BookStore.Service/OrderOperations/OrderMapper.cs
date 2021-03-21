using AutoMapper;
using BookStore.DataAccess.Entities;

namespace BookStore.Service.OrderOperations
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderDto, Order>();
        }
    }
}
