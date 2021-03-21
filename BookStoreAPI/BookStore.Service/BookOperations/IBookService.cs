using System.Collections.Generic;

namespace BookStore.Service.BookOperations
{
    public interface IBookService
    {
        IList<BookDto> GetAll();
        IList<BookTypeDto> GetBookTypes();
        BookDto Create(BookDto bookDto);
    }
}
