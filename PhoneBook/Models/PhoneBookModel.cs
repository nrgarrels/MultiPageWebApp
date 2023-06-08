using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class PhoneBookModel
    {
        public int PhoneBookId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter a Bite.")]
        public string? Note { get; set; }
    }
}

