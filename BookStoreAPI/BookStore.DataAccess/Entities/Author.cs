using System.Collections.Generic;

namespace BookStore.DataAccess.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookAuthorLink> BookAuthorLinks { get; set; }
    }
}
