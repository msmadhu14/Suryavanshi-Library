using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuryavanshiLibrary.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public String BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }

    }
}
