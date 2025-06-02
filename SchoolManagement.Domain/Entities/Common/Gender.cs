using SchoolManagement.Domain.CustomEntityColumns;

namespace SchoolManagement.Domain.Entities.Common;

public class Gender:Entity
{
    public string Name { get; set; }
    public string NameNepali { get; set; }
    public bool IsActive { get; set; }
}