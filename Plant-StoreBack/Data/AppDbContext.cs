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
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Featured> Featureds { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Interested> interesteds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProduct> WishlistProducts { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setting>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Banner>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Elementor>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Featured>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Help>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<ProductImage>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Testimonial>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Team>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Company>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<About>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<ContactMessage>().HasQueryFilter(m => !m.SoftDeleted);

        }

    }
}
