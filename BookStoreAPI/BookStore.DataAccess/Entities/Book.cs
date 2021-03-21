using System.Collections.Generic;

namespace BookStore.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int BookTypeId { get; set; }
        public virtual BookType BookType { get; set; }
        public virtual ICollection<BookAuthorLink> BookAuthorLinks { get; set; }
        public virtual ICollection<BookOrderLink> BookOrderLinks { get; set; }

    }
}
