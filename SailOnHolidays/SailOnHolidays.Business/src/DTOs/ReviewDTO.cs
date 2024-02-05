using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class ReviewReadDTO
    {
        public int StarRating { get; set; }
        public required string Comment { get; set; }
        public Guid UserId { get; set; }
        public required User User { get; set; }
        public Guid YachtId { get; set; }
        public required Yacht Yacht { get; set; }
    }
    public class ReviewCreateDTO
    {
        public int StarRating { get; set; }
        public required string Comment { get; set; }
        public Guid ProductId { get; set; }
    }
    public class ReviewUpdateDTO
    {
        public int? StarRating { get; set; }
        public string? Comment { get; set; }
    }
}