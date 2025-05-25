using System.ComponentModel.DataAnnotations;

namespace ArgusMedia.Restaurant.Dtos
{
    public class BillDto
    {
        [Required]
        public IEnumerable<Guid> ClientIds { get; set; }

        public bool IsSplit { get; set; } = false;
    }
}
