using System.ComponentModel.DataAnnotations;

namespace ArgusMedia.Restaurant.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid ProductId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
