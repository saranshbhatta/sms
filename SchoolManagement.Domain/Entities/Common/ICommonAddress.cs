namespace SchoolManagement.Domain.Entities.Common
{
    public interface ICommonAddress
    {
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int MunicipalityId { get; set; }
        public string Tole { get; set; }
    }
}
