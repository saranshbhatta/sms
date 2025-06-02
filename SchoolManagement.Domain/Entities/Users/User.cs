using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagement.Domain.CustomEntityColumns;
using SchoolManagement.Domain.Entities.PeopleEntity;

namespace SchoolManagement.Domain.Entities.Users;

public class User : FullyAuditedEntity
{
    [ForeignKey("PeopleInfo")]
    public int PeopleId { get; set; }
    public People PeopleInfo { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}