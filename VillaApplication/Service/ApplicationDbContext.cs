using Microsoft.EntityFrameworkCore;
using VillaApplication.Model.Data;

namespace VillaApplication.Service
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Villa> Villas { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
