using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.OrderOperations
{
    public class OrderDto
    {
        [Required(ErrorMessage = "User Full Name is required")]
        public string UserFullName { get; set; }
        [Required(ErrorMessage = "Address Line One is required")]
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
        public string PinCode { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "BookIds is required")]
        [MinLength(1)]
        public IList<BookQuantityDto> Books { get; set; }
    }
}
