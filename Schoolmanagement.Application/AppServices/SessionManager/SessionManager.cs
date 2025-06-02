using System.Text.Json;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.AppServices.SessionManager.Dto;
using SchoolManagement.Domain.Entities.Users;

namespace SchoolManagement.Application.AppServices.SessionManager;

public class SessionManager(IHttpContextAccessor httpContextAccessor)
    :ISessionManager
{
    
    
    public async Task SetUserSession(User user)
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext == null) return;

        var userSession = new UserSessionDto
        {
            UserName = user.UserName,
            Userid = user.Id,
            Name = user.PeopleInfo.FullName
        };
        var jsonValue = JsonSerializer.Serialize(userSession);
    }
    
}