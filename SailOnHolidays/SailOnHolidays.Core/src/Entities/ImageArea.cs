namespace SailOnHolidays.Core.src.Entities
{
    public class ImageArea
    {
        public Guid YachtId { get; set; }
        public required Yacht Yacht { get; set; }
        public required byte[] Data { get; set; }
    }
}