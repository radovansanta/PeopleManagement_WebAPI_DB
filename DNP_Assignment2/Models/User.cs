using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DNP_Assignment2.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}