using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Repository;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.DbContextProvider;
using SchoolManagement.Infrastructure.Repository;

namespace SchoolManagement.Web.Host.ServiceCollection
{
    public static class DbContextServices
    {
        public static void SchoolManagementDbContextServices(this IServiceCollection services)
        {

            
            //db context service collection
            services.AddScoped<IDbContextProvider, DbContextProvider>();
            SchoolManagementAllRepositoryServices(services);
        }

        private static void SchoolManagementAllRepositoryServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            var dbContext = provider.GetRequiredService<SchoolManagementDbContext>();
            var allTables = dbContext.Model.GetEntityTypes();

            foreach (var table in allTables)
            {
                var entityType = table.ClrType;
                var repositoryInterface = typeof(IRepository<>).MakeGenericType(entityType);
                var repositoryImplementation = typeof(Repository<>).MakeGenericType(entityType);

                services.AddScoped(repositoryInterface, repositoryImplementation);
            }
        }
    }
}
