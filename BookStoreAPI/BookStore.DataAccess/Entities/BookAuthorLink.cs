﻿namespace BookStore.DataAccess.Entities
{
    public class BookAuthorLink
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
