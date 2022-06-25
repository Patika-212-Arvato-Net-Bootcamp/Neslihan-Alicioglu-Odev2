using ODEV_2.Models;
using ODEV_2.Repositories.Abstract;
using ODEV_2.Services.Abstract;

namespace ODEV_2.Services
{
    public class BootcampService : Service<Bootcamp>, IBootcampService
    {
        public BootcampService(IRepository<Bootcamp> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
