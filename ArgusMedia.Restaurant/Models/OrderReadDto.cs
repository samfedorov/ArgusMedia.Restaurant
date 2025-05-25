namespace ArgusMedia.Restaurant.Models
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid ProductId { get; set; }
    }
}
