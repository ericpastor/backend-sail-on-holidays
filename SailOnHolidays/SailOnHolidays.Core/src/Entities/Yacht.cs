using System.Text.Json.Serialization;

namespace SailOnHolidays.Core.src.Entities
{
    public class Yacht
    {
        public Enum RentalType { get; set; }
        public string Name { get; set; }
        public string Manufacter { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public int Beam { get; set; }
        public int Draft { get; set; }
        public int Capacity { get; set; }
        public int Cabins { get; set; }
        public int Heads { get; set; }
        public string Description { get; set; }
        public IEnumerable<ImageYacht> ImageYachts { get; set; }
        public Features Features { get; set; }
        public ConditionsAndTerms ConditionsAndTerms { get; set; }
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