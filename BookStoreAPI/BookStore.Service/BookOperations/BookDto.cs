using BookStore.Service.AuthorOperations;
using System.Collections.Generic;

namespace BookStore.Service.BookOperations
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailble { get; set; }
        public int Quantity { get; set; }
        public int BookTypeId { get; set; }
        public IList<AuthorDto> Authors { get; set; }
    }
}
