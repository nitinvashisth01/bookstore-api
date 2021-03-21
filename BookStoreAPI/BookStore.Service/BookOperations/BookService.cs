using AutoMapper;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.RepositoryInterfaces;
using BookStore.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Service.BookOperations
{
    public class BookService : IBookService
    {
        #region Class Members

        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<BookType> _bookTypeRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public BookService(IGenericRepository<Book> bookRepository, IGenericRepository<BookType> bookTypeRepository,
                           IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Interface Implementation

        public IList<BookDto> GetAll()
        {
            var books = _bookRepository.GetAll();

            return _mapper.Map<IEnumerable<Book>, List<BookDto>>(books);
        }

        public IList<BookTypeDto> GetBookTypes()
        {
            var bookTypes = _bookTypeRepository.GetAll();

            return _mapper.Map<IEnumerable<BookType>, List<BookTypeDto>>(bookTypes);
        }

        public BookDto Create(BookDto bookDto)
        {
            _unitOfWork.BeginTransaction();

            var book = _mapper.Map<Book>(bookDto);

            var bookType = _bookTypeRepository.GetById(bookDto.BookTypeId);

            if(bookType == null)
            {
                throw new NotFoundException(Resource.BookTypeNotFound);
            }

            book.BookAuthorLinks = new List<BookAuthorLink>();

            foreach(var author in bookDto.Authors)
            {
                book.BookAuthorLinks.Add(new BookAuthorLink {
                    AuthorId = author.AuthorId
                });
            }

            _bookRepository.Add(book);
            _bookRepository.Save();

            _unitOfWork.Commit();

            return _mapper.Map<BookDto>(book);
        }

        #endregion
    }
}
