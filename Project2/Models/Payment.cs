using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Name of Payment can't be blank")]
        public string PaymentName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string CardNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string ExpiryDate { get; set; }
        [Required]
        [MaxLength(3)]
        [RegularExpression("^[0-9]{3, 4}$")]
        public int CvvNo { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string PaymentMode { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
