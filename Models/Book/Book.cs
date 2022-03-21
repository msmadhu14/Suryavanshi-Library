

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuryavanshiLibrary.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        public string PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public bool IssuedStatus { get; set; }
        public bool IsDeleted { get; set; }


    }
}
