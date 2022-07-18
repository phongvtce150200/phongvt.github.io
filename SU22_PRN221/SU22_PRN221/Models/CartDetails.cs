using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRN221.Models
{

    [Table("CartDetails")]
    public class CartDetails
    {
        [Key]
        public int CartId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
