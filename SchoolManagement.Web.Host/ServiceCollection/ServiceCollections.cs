using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure;

namespace SchoolManagement.Web.Host.ServiceCollection
{
    public static class ServiceCollections
    {
        public static IServiceCollection SchoolManagementApplicationCollectionList(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SchoolManagementDbContext>(options => 
                options.UseNpgsql(config.GetConnectionString("DbConnString")));
            //db context service collection

            services.SchoolManagementDbContextServices();

            return services;
        }
    }
}
