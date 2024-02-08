namespace SailOnHolidays.Core.src.Entities
{
    public class ConditionsAndTerms : BaseEntity
    {
        public Guid YachtIdForConditionsAndTerms { get; set; }
        public bool SmokingAllowed { get; set; }
        public bool PartyAllowed { get; set; }
        public bool PetsAllowed { get; set; }
        public bool ChildrenAllowed { get; set; }
    }
}