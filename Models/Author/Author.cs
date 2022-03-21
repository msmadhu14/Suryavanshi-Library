using System.ComponentModel.DataAnnotations;

namespace SuryavanshiLibrary.Models
{
    public class Author
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
