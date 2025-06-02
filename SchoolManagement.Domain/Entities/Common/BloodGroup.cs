using SchoolManagement.Domain.CustomEntityColumns;

namespace SchoolManagement.Domain.Entities.Common;

public class BloodGroup:Entity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}