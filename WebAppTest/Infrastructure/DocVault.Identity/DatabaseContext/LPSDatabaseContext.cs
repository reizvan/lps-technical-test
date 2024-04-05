using DocVault.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocVault.Identity.DatabaseContext
{
    public class LPSDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public LPSDatabaseContext(DbContextOptions<LPSDatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LPSDatabaseContext).Assembly);
        }
    }
}
