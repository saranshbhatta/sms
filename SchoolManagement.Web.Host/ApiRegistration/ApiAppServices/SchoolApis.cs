using SchoolManagement.Application.AppServices.SchoolAppService;
using SchoolManagement.Application.AppServices.SchoolAppService.Dto;

namespace SchoolManagement.Web.Host.ApiRegistration.ApiAppServices;

public static class SchoolApis
{
    private const string RoutePrefix = "api/v1/School";
    public static void RegisterSchoolApis(this WebApplication app)
    {
        app.MapGet($"{RoutePrefix}/GetAll",GetAllSchools);
        app.MapPost($"{RoutePrefix}/Create",Create);
    }

    private static async Task<IResult> GetAllSchools(ISchoolAppService repo)
    {
        var result = await repo.GetAllSchools();
        return Wrapper.Success(result);
    }    
    private static async Task<IResult> Create(ISchoolAppService repo, SchoolCreateDto input)
    {
        await repo.Create(input);
        return Wrapper.Success();
    }
}