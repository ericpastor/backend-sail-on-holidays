namespace SailOnHolidays.Business.src.DTOs
{
    public class ImageAreaDTO
    {
        public Guid AreaId { get; set; }
        public required byte[] Data { get; set; }
        public required string IamgeAreaBase64Data { get; set; }
    }

    public class ImageAreaCreateDTO
    {
        public Guid AreaId { get; set; }
        public required byte[] Data { get; set; }
    }
    public class ImageAreaUpdateDTO
    {
        public Guid Id { get; set; }
        public byte[]? Data { get; set; }
    }
}