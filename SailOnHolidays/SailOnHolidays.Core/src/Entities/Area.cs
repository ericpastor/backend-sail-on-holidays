namespace SailOnHolidays.Core.src.Entities
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }
        public ImageArea ImageArea { get; set; }
        public IEnumerable<Yacht> Yachts { get; set; }
    }
}