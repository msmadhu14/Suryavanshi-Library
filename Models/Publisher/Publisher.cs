using System.ComponentModel.DataAnnotations;

namespace SuryavanshiLibrary.Models
{
    public class Publisher
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Notes { get; set; }

    }
}
