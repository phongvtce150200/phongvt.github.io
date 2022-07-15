using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRN221.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
