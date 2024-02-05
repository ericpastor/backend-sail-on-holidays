namespace SailOnHolidays.Core.src.Entities
{
    public class Area : BaseEntity
    {
        public required string Name { get; set; }
        public required ImageArea ImageArea { get; set; }
        public IEnumerable<Yacht> Yachts { get; } = new List<Yacht>();
    }
}