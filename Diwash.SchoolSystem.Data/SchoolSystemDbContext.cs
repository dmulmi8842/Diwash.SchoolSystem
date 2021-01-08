using Diwash.SchoolSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diwash.SchoolSystem.Data
{
    public class SchoolSystemDbContext: DbContext
    {
        public SchoolSystemDbContext(DbContextOptions<SchoolSystemDbContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

    }
}
