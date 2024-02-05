using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class YachtReadDTO : BaseEntity
    {
        public Guid AreaId { get; set; }
        public required Area Area { get; set; }
        public required string Name { get; set; }
        public required string Manufacter { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public int Beam { get; set; }
        public int Draft { get; set; }
        public int Capacity { get; set; }
        public int Cabins { get; set; }
        public int Heads { get; set; }
        public required string Description { get; set; }
        public RentalType RentalType { get; set; }
        public required IEnumerable<ImageYacht> ImageYachts { get; set; }
        public required Features Features { get; set; }
        public required ConditionsAndTerms ConditionsAndTerms { get; set; }
        public decimal? PricePerHour { get; set; }
        public decimal? PricePerDay { get; set; }
        public decimal PricePerWeek { get; set; }
    }


    public class YachtCreateDTO
    {
        public Guid AreaId { get; set; }
        public required string Name { get; set; }
        public required string Manufacter { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public int Beam { get; set; }
        public int Draft { get; set; }
        public int Capacity { get; set; }
        public int Cabins { get; set; }
        public int Heads { get; set; }
        public required string Description { get; set; }
        public RentalType RentalType { get; set; }
        public IEnumerable<ImageYachtReadDTO> ImagesYacht { get; } = new List<ImageYachtReadDTO>();
        public required Features Features { get; set; }
        public required ConditionsAndTermsCreateDTO ConditionsAndTerms { get; set; }
        public decimal? PricePerHour { get; set; }
        public decimal? PricePerDay { get; set; }
        public decimal PricePerWeek { get; set; }
    }

    public class YachtUpdateDTO
    {
        public Guid? AreaId { get; set; }
        public string? Name { get; set; }
        public string? Manufacter { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public int Beam { get; set; }
        public int Draft { get; set; }
        public int Capacity { get; set; }
        public int Cabins { get; set; }
        public int Heads { get; set; }
        public string? Description { get; set; }
        public RentalType RentalType { get; set; }
        public List<ImageYachtCreateDTO> ImagesYacht { get; set; } = [];
        public FeaturesUpdateDTO? Features { get; set; }
        public ConditionsAndTermsUpdateDTO? ConditionsAndTerms { get; set; }
        public decimal? PricePerHour { get; set; }
        public decimal? PricePerDay { get; set; }
        public decimal PricePerWeek { get; set; }
    }
}