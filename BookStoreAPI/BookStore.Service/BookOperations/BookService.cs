using AutoMapper;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Service.BookOperations
{
    public class BookService : IBookService
    {
        #region Class Members

        private readonly IGenericRepository<Book> _bookRepository;

        private IMapper _mapper;

        #endregion

        #region Constructor

        public BookService(IGenericRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        #endregion

        #region Interface Implementation

        public IList<BookDto> GetAll()
        {
            var books = _bookRepository.GetAll();

            return _mapper.Map<IEnumerable<Book>, List<BookDto>>(books);
        }

        #endregion
    }
}
