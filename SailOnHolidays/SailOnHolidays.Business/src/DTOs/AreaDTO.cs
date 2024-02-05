using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class AreaReadDTO : BaseEntity
    {
        public required string Name { get; set; }
        public required ImageArea ImageArea { get; set; }
    }
    public class AreaCreateDTO
    {
        public required string Name { get; set; }
        public required ImageArea ImageArea { get; set; }
    }

    public class AreaUpdateDTO
    {
        public string? Name { get; set; }
        public ImageArea? ImageArea { get; set; }
    }
}