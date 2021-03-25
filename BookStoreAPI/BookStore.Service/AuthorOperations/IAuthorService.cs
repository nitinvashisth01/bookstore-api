using System.Collections.Generic;

namespace BookStore.Service.AuthorOperations
{
    public interface IAuthorService
    {
        IList<AuthorDto> GetAll();
        AuthorDto Create(AuthorDto authorDto);
    }
}
