using Microsoft.EntityFrameworkCore;
using VendorManagementApp.Models;

namespace VendorManagementApp.DAL
{
    public class VendorDbContext : DbContext
    {
        public VendorDbContext(DbContextOptions<VendorDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can configure additional settings for your entities here
            // Example: modelBuilder.Entity<Vendor>().Property(v => v.FirstName).IsRequired();
        }
    }
}