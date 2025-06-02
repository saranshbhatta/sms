using SchoolManagement.Domain.CustomEntityColumns;
using SchoolManagement.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Domain.Entities.School
{
    public class SchoolAddress : Entity, ICommonAddress
    {
        [ForeignKey("SchoolInfo")]
        public int SchoolId { get; set; }
        public School SchoolInfo { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int MunicipalityId { get; set; }
        public string Tole { get; set; }
    }
}
