using ODEV_2.Data;
using ODEV_2.Repositories.Abstract;

namespace ODEV_2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();//.Result ile de senkron yapıya çevirilebilir
        }
    }
}
