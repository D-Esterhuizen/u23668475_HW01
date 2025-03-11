using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace u23668475_HW01.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        public string productName { get; set; }= string.Empty;

        [Required]
        public string productDescription { get; set; }= string.Empty;

        [Required]
        public int productPrice { get; set; } = 0;
         


    }
}
