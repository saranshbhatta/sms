
using SchoolManagement.Application.AppServices.SchoolAppService.Dto;
using SchoolManagement.Domain.Entities.School;
using SchoolManagement.Domain.Repository;

namespace SchoolManagement.Application.AppServices.SchoolAppService;

public class SchoolAppService (
    IRepository<School> schoolRepository
    )
    
    :ISchoolAppService
{
    public async Task Create(SchoolCreateDto input)
    {
        var school = new School
        {
            Name = input.SchoolName,
            NameNepali = input.SchoolNameNepali,
            DateOfEstablishmentAd = input.DateOfEstablishmentAd,
            DateOfEstablishmentBs = input.DateOfEstablishmentBs
        };
        await schoolRepository.InsertAsync(school);
    }
    
    public async Task<IEnumerable<School>> GetAllSchools()
    {
        var result = await schoolRepository.GetAllAsync();
        return result;
    }
}