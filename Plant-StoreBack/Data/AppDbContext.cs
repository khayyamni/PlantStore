using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Models;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Security.Cryptography.Pkcs;

namespace Plant_StoreBack.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Elementor> Elementors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Banner>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Elementor>().HasQueryFilter(m => !m.SoftDeleted);
        }

    }
}
