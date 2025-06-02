using System.Linq.Expressions;

namespace SchoolManagement.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity tableData);
        Task InsertRangeAsync(IEnumerable<TEntity> tableData);
        Task UpdateAsync(TEntity tableData);
        Task UpdateMultipleAsync(IEnumerable<TEntity> tableData);
        Task DeleteAsync(long id);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
