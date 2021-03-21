using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataAccess.Entities
{
    public class BookType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
