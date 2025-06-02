using SchoolManagement.Application.AppServices.UserAppService;

namespace SchoolManagement.Web.Host.ApiRegistration.ApiAppServices;

public static class UserApis
{
    private const string RoutePrefix = "api/v1/User";
    public static void RegisterUserApis(this WebApplication app)
    {
        app.MapGet($"{RoutePrefix}/GetAllUsers",GetAllUsers);

    }

    private static async Task<string> GetAllUsers(IUserAppService repo)
    {
        return await repo.GetAllUsers();
    }
}