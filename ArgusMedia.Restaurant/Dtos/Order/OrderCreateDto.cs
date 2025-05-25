using System.ComponentModel.DataAnnotations;

namespace ArgusMedia.Restaurant.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid ClientId { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
