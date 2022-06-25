using ODEV_2.Models;
using System.Linq.Expressions;

namespace ODEV_2.Services.Abstract
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id); //Kullanıcı bir id gönderdiği zaman T tablosundan bulup geri gönderecek

        IQueryable<T> Where(Expression<Func<T, bool>> expression);//Sorgular veritabanına gitmez ilk önce sorgu yapılır

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);//Var mı, yok mu?

        T GetOne(Expression<Func<T, bool>> filter);//Kullanıcı geriye tek bir eleman döndürürse, bulduğu ilk kayıt

        Task AddAsync(T entity);

        Task Update(T entity); //burada db de saveCheanges yapılacağı içn async

        Task Delete(T entity);
    }
}
