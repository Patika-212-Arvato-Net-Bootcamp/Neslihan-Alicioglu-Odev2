using System.Linq.Expressions;

namespace ODEV_2.Repositories.Abstract
{
    //Repository Pattern kullandım. 
    //Repository Pattern:Veri merkezli uygulamalarda veriye erişimin ve yönetimin tek noktaya indirilmesini sağlayan yapıya denir. 


    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll(); //Bulduğu bütün kayıtları geri alsın

        Task<T> GetByIdAsync(Guid id); //Kullanıcı bir id gönderdiği zaman T tablosundan bulup geri gönderecek

        IQueryable<T> Where(Expression<Func<T,bool>> expression);//Sorgular veritabanına gitmez ilk önce sorgu yapılır

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);//Var mı, yok mu?

        T GetOne(Expression<Func<T, bool>> filter);//Kullanıcı geriye tek bir eleman döndürürse, bulduğu ilk kayıt
       
        Task AddAsync(T entity);

        void Update(T entity); //Class ın sadece state ini modifide olarak değiştirdiği için async değil

        void Delete(T entity);
    }
}
