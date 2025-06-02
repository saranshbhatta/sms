namespace SchoolManagement.Application.AppServices.UserAppService;

public class UserAppService:IUserAppService
{
    public async Task<string> GetAllUsers()
    {
        await Task.Delay(1000);
        return "users";
    }
}