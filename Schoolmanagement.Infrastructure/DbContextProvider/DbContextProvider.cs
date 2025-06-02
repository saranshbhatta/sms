using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure;

namespace SchoolManagement.Infrastructure.DbContextProvider
{
    public class DbContextProvider : IDbContextProvider
    {
        private readonly SchoolManagementDbContext _context;

        // Inject the fully-configured DbContext instead of options
        public DbContextProvider(SchoolManagementDbContext context)
        {
            _context = context;
        }

        public SchoolManagementDbContext GetDbContext()
        {
            return _context;
        }
    }
}