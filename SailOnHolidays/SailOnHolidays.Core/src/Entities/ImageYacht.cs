namespace SailOnHolidays.Core.src.Entities
{
    public class ImageYacht : BaseEntity
    {
        public Guid YachtIdForImage { get; set; }
        public required byte[] Data { get; set; }
    }
}