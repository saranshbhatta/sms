using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.CustomEntityColumns;
using SchoolManagement.Domain.Repository;
using SchoolManagement.Infrastructure.DbContextProvider;

namespace SchoolManagement.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SchoolManagementDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        //private readonly IDbContextProvider _dbContextProvider;
        public Repository(IDbContextProvider dbContextProvider)
        {
            _context =dbContextProvider.GetDbContext();
            _dbSet = _context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        
        public async Task InsertAsync(TEntity tableData)
        {
            try
            {
                if (tableData is FullyAuditedEntity auditedEntity)
                {
                    auditedEntity.CreationTime = DateTime.Now;
                    auditedEntity.CreatorUserId = 1; 
                }
                await _dbSet.AddAsync(tableData);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task InsertRangeAsync(IEnumerable<TEntity> tableData)
        {
            var currentTime = DateTime.Now;

            foreach (var entity in tableData)
            {
                if (entity is FullyAuditedEntity auditedEntity)
                {
                    auditedEntity.CreationTime = currentTime;
                    auditedEntity.CreatorUserId = currentUserId;
                }
            }
            await _dbSet.AddRangeAsync(tableData);
        }

        public async Task UpdateAsync(TEntity tableData)
        {
            if (tableData is FullyAuditedEntity auditedEntity)
            {
                auditedEntity.LastModifiedTime = DateTime.Now;
                auditedEntity.CreatorUserId = currentUserId;
            }
            _dbSet.Update(tableData);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMultipleAsync(IEnumerable<TEntity> tableData)
        {
            
            foreach (var entity in tableData)
            {
                if (entity is FullyAuditedEntity auditedEntity)
                {
                    auditedEntity.CreationTime = DateTime.Now;
                    auditedEntity.CreatorUserId = currentUserId;
                }
            }
            _dbSet.UpdateRange(tableData);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(long id)
        {
            TEntity data = _dbSet.Find(id) ??
               throw new ArgumentNullException();
            
            if (data is FullyAuditedEntity auditedEntity)
            {
                auditedEntity.DeletionTime = DateTime.Now;
                auditedEntity.DeletionUserId = currentUserId;
            }
            _dbSet.Remove(data);
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        private int currentUserId { get; set; } = 1;
    }
}
