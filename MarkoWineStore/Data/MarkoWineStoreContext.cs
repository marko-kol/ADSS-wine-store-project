using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarkoWineStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarkoWineStore.Data
{
    public class MarkoWineStoreContext : IdentityDbContext<ApplicationUser>
    {
        public MarkoWineStoreContext (DbContextOptions<MarkoWineStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.firstName)
                .HasMaxLength(250);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.lastName)
                .HasMaxLength(250);

        }

        public DbSet<MarkoWineStore.Models.Wine> Wine { get; set; }
    }
}
