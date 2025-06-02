using SchoolManagement.Web.Host.ApiRegistration.ApiAppServices;

namespace SchoolManagement.Web.Host.ApiRegistration;

public static class ApiCollection
{
    public static void RegisterAppApis(this WebApplication app)
    {
        app.RegisterSchoolApis();

        app.RegisterUserApis();
    }
}


