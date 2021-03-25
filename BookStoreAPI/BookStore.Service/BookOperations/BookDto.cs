using BookStore.Service.AuthorOperations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.BookOperations
{
    public class BookDto
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "BookName is required")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        [Required(ErrorMessage = "BookType is required")]
        public int BookTypeId { get; set; }
        [Required(ErrorMessage = "Atleast one author is required")]
        [MinLength(1)]
        public IList<AuthorDto> Authors { get; set; }
    }
}
