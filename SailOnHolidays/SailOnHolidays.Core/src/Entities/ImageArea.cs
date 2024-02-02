namespace SailOnHolidays.Core.src.Entities
{
    public class ImageArea
    {
        public Guid YachtId { get; set; }
        public Yacht Yacht { get; set; }
        public byte[] Data { get; set; }
    }
}