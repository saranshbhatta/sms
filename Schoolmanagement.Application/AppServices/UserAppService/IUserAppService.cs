namespace SchoolManagement.Application.AppServices.UserAppService;

public interface IUserAppService
{
    Task<string> GetAllUsers();
}