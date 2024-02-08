using System.Text.Json.Serialization;

namespace SailOnHolidays.Core.src.Entities
{
    public class Yacht : BaseEntity
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
        public required RentalType RentalType { get; set; }
        public IEnumerable<ImageYacht> ImageYachts { get; set; } = new List<ImageYacht>();
        public Features Features { get; set; } = new Features();
        public ConditionsAndTerms ConditionsAndTerms { get; set; } = new ConditionsAndTerms();
        public decimal? PricePerHour { get; set; }
        public decimal? PricePerDay { get; set; }
        public decimal PricePerWeek { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum RentalType
    {
        Crewed,
        Bareboat,
    }
}