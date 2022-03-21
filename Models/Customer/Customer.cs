using System.ComponentModel.DataAnnotations;

namespace SuryavanshiLibrary.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

    }
}
