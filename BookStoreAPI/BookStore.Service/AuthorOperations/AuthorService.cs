using AutoMapper;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Service.AuthorOperations
{
    public class AuthorService : IAuthorService
    {
        #region Class Members

        private readonly IGenericRepository<Author> _authorRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public AuthorService(IGenericRepository<Author> authorRepository, IMapper mapper,
                             IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Interface Implementation

        public IList<AuthorDto> GetAll()
        {
            var authors = _authorRepository.GetAll();

            return _mapper.Map<IEnumerable<Author>, List<AuthorDto>>(authors);
        }

        public AuthorDto Create(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);

            _unitOfWork.BeginTransaction();

            _authorRepository.Add(author);
            _authorRepository.Save();

            _unitOfWork.Commit();

            return _mapper.Map<AuthorDto>(author);
        }

        #endregion
    }
}
