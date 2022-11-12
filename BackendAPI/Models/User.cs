using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
