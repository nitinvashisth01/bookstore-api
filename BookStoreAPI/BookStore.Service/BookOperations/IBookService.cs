using System.Collections.Generic;

namespace BookStore.Service.BookOperations
{
    public interface IBookService
    {
        IList<BookDto> GetAll();
        BookDto Create(BookDto bookDto);
    }
}
