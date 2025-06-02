using SchoolManagement.Domain.CustomEntityColumns;

namespace SchoolManagement.Domain.Entities.School
{
    public class School : FullyAuditedEntity
    {
        public string Name { get; set; }
        public string NameNepali { get; set; }
        public DateOnly DateOfEstablishmentAd { get; set; }
        public string DateOfEstablishmentBs { get; set; }
    }
}
