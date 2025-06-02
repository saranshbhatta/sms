using SchoolManagement.Application.AppServices.SecurityAppService;

namespace SchoolManagement.Web.Host.ApiRegistration.ApiAppServices;

public static class SecurityApis
{
    private const string RoutePrefix = "api/v1/Security";
    public static void RegisterSecurityApis(this WebApplication app)
    {
        app.MapPost($"{RoutePrefix}/login",Login);
    }

    private static async Task<IResult> Login(ISecurityAppService repo, string username, string password)
    {
        var result = await repo.Login(username,password);
        return Wrapper.Success(result);
    }
}