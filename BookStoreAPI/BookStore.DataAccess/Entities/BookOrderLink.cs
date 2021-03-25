namespace BookStore.DataAccess.Entities
{
    public class BookOrderLink
    {
        public int Id { get; set; }

        public int OrderQuantity { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
