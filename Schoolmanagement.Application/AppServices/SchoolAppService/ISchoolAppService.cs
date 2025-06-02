using SchoolManagement.Application.AppServices.SchoolAppService.Dto;
using SchoolManagement.Domain.Entities.School;

namespace SchoolManagement.Application.AppServices.SchoolAppService;

public interface ISchoolAppService
{
    Task<IEnumerable<School>> GetAllSchools();
    Task Create(SchoolCreateDto input);
}