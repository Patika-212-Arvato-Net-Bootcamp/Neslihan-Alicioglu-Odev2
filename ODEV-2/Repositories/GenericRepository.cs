using Microsoft.EntityFrameworkCore;
using ODEV_2.Data;
using ODEV_2.Repositories.Abstract;
using System.Linq.Expressions;

namespace ODEV_2.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _databaseContext; //Burada olmayan methodlara ait sorguyu yapabilmek için protected
                                                             //protected : miras alınan yerde erişilebilir sadece
        private readonly DbSet<T> _dbSet; //DbSet veritabanındaki tabloya karşılık gelir

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext= databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable(); //AsNoTracking() : EF Core aldığı dataları direkt memory ye almasın daha işlevli çalışsın diye
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return _dbSet.AsNoTracking().AsQueryable().Where(filter).SingleOrDefault();//Bulduğu ilk kaydı alsın bulamazsa da null değer göndersin
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

      
    }
}
