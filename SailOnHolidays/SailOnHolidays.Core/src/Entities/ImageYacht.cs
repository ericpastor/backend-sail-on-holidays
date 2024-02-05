namespace SailOnHolidays.Core.src.Entities
{
    public class ImageYacht : BaseEntity
    {
        public Guid YachtId { get; set; }
        public required Yacht Yacht { get; set; }
        public required byte[] Data { get; set; }
    }
}