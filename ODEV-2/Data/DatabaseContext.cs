using Microsoft.EntityFrameworkCore;
using ODEV_2.Models;

namespace ODEV_2.Data
{
    public class DatabaseContext:DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }

        public DbSet<Bootcamp> Bootcamps { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
