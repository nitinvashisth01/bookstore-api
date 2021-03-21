using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.AuthorOperations
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "AuthorName is required")]
        public string AuthorName { get; set; }
    }
}
