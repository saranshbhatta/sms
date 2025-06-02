namespace SchoolManagement.Application.AppServices.SecurityAppService;

public interface ISecurityAppService
{
    Task<string>Login(string userName, string password);
}