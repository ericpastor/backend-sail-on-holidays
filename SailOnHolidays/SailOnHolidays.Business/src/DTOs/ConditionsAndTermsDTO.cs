using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class ConditionsAndTermsReadDTO : BaseEntity
    {
        public Guid YachtId { get; set; }
        public bool SmokingAllowed { get; set; }
        public bool PartyAllowed { get; set; }
        public bool PetsAllowed { get; set; }
        public bool ChildrenAllowed { get; set; }
    }

    public class ConditionsAndTermsCreateDTO
    {
        public Guid YachtId { get; set; }
        public bool SmokingAllowed { get; set; }
        public bool PartyAllowed { get; set; }
        public bool PetsAllowed { get; set; }
        public bool ChildrenAllowed { get; set; }
    }

    public class ConditionsAndTermsUpdateDTO
    {
        public Guid YachtId { get; set; }
        public bool SmokingAllowed { get; set; }
        public bool PartyAllowed { get; set; }
        public bool PetsAllowed { get; set; }
        public bool ChildrenAllowed { get; set; }
    }

}