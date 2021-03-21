using AutoMapper;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.RepositoryInterfaces;
using BookStore.Utils.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Service.OrderOperations
{
    public class OrderService : IOrderService
    {
        #region Class Members

        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Book> _bookRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<Book> bookRepository,
                            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Interface Implementation

        public async Task Create(OrderDto orderDto)
        {
            _unitOfWork.BeginTransaction();

            var order = _mapper.Map<Order>(orderDto);

            var bookOrderLinks = new List<BookOrderLink>();

            foreach(var book in orderDto.Books)
            {
                var bookEntity = _bookRepository.GetById(book.BookId);

                if(bookEntity == null)
                {
                    throw new NotFoundException(Resource.BookNotFound);
                }

                if(!bookEntity.IsAvailable || bookEntity.Quantity < book.Quantity)
                {
                    throw new BadRequestException(Resource.BookNotAvailable);
                }

                var bookOrderLink = new BookOrderLink
                {
                    BookId = bookEntity.Id,
                    OrderQuantity = book.Quantity
                };

                bookOrderLinks.Add(bookOrderLink);

                bookEntity.Quantity = bookEntity.Quantity - book.Quantity;
                bookEntity.IsAvailable = bookEntity.Quantity > 0;
            }

            order.BookOrderLinks = bookOrderLinks;

            await _orderRepository.AddAsync(order);
            _orderRepository.Save();

            _unitOfWork.Commit();
        }

        #endregion
    }
}
