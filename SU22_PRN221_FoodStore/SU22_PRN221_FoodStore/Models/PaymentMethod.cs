using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRN221_FoodStore.Models
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string PaymentMethodName { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}