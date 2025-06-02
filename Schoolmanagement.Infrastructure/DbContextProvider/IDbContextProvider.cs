namespace SchoolManagement.Infrastructure.DbContextProvider
{
    public interface IDbContextProvider
    {
        SchoolManagementDbContext GetDbContext();
    }
}
