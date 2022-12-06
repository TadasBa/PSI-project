using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Recepie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string ImageSource { get; set; }
    }
}
