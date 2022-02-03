using GenericRepositoryUOWorkWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryUOWorkWebAPI.Data
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Personel> Personeller { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
