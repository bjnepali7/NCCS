using Microsoft.EntityFrameworkCore;

namespace EFCoreNCCSB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }  // ✅ Parameterless constructor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Officer> Officers { get; set; } // This represents tbl_officer
    }
}