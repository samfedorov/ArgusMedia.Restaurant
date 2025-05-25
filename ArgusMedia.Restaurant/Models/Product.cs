using System.ComponentModel.DataAnnotations;

namespace ArgusMedia.Restaurant.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public bool IsDrink { get; set; }
    }
}
