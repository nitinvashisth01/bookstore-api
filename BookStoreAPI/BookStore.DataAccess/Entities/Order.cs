using System.Collections.Generic;

namespace BookStore.DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual ICollection<BookOrderLink> BookOrderLinks { get; set; }
    }
}
