namespace SailOnHolidays.Core.src.Entities
{
    public class ImageArea : BaseEntity
    {
        public Guid AreaIdForImage { get; set; }
        public required byte[] Data { get; set; }
    }
}