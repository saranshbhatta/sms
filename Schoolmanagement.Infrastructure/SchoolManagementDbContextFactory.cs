using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Infrastructure
{
    public class SchoolManagementDbContextFactory : IDesignTimeDbContextFactory<SchoolManagementDbContext>
    {
        public SchoolManagementDbContext CreateDbContext(string[] args)
        {
            // Try to find the Web project's appsettings.json
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "SchoolManagement.Web.Host");
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DbConnString");
            
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Could not find connection string 'DbConnString'");

            var builder = new DbContextOptionsBuilder<SchoolManagementDbContext>();
            builder.UseNpgsql(connectionString);

            return new SchoolManagementDbContext(builder.Options);
        }
    }
}