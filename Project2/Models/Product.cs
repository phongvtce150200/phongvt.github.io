using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name of Product can't be blank")]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null;
        [Required(ErrorMessage = "Price of product can't be blank")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string ImageUrl { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
