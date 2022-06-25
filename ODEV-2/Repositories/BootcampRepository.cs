using ODEV_2.Data;
using ODEV_2.Models;
using ODEV_2.Repositories.Abstract;

namespace ODEV_2.Repositories
{
    public class BootcampRepository : GenericRepository<Bootcamp>, IBootcampRepository
    {
        public BootcampRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
