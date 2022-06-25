using ODEV_2.Models;
using ODEV_2.Repositories.Abstract;
using ODEV_2.Services.Abstract;

namespace ODEV_2.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

    }
}
