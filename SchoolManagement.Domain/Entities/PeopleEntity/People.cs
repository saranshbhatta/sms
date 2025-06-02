using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagement.Domain.CustomEntityColumns;
using SchoolManagement.Domain.Entities.Common;

namespace SchoolManagement.Domain.Entities.PeopleEntity;

public class People : FullyAuditedEntity
{
    public string FirstName { get; set; }
    
    public string middleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    [ForeignKey("GenderInfo")]
    public int GenderId { get; set; }
    public Gender GenderInfo { get; set; }
    [ForeignKey("MaritalStatusInfo")]
    public int MaritalStatusId { get; set; }
    public MaritalStatus MaritalStatusInfo { get; set; }
    [ForeignKey("ReligionInfo")]
    public int ReligionId { get; set; }
    public Religion ReligionInfo { get; set; }
    [ForeignKey("BloodGroupInfo")]
    public int BloodGroupId { get; set; }
    public BloodGroup BloodGroupInfo { get; set; }
    [ForeignKey("NationalityInfo")]
    public int NationalityId { get; set; }
    public Nationality NationalityInfo { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}