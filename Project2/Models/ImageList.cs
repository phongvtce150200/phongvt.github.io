using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    [Table("ImageList")]
    public class ImageList
    {
        [Key]
        public int ImageId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string ImagePath { get; set; }
        public ICollection<Product> Carts { get; set; }
    }
}