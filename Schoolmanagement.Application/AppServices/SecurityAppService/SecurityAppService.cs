using SchoolManagement.Domain.Entities.Users;
using SchoolManagement.Domain.Repository;

namespace SchoolManagement.Application.AppServices.SecurityAppService;

public class SecurityAppService(
    IRepository<User> userRepository
    )
    
    : ISecurityAppService
{


    public async Task<string> Login(string userName , string password)
    {
        // var isValidUser = await (await userRepository.GetAll())
        var user = await userRepository.GetFirstOrDefaultAsync(x=>x.UserName == userName && x.Password == password)??
                   throw new Exception("Provide valuid user");
        
        return user.UserName;
    }
    
}