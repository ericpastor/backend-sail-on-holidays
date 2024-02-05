using System.ComponentModel.DataAnnotations;

namespace SailOnHolidays.Core.src.Entities
{
    public class Review
    {
        public Guid UserId { get; set; }
        public Guid YachtId { get; set; }
        public required string Comment { get; set; }
        [Range(1, 5)]
        public int StarRating { get; set; }
    }
}