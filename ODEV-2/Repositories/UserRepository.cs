using ODEV_2.Data;
using ODEV_2.Models;
using ODEV_2.Repositories.Abstract;

namespace ODEV_2.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        
    }
}
