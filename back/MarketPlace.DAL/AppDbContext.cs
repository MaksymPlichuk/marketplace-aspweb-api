using MarketPlace.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL   
{
    public class AppDbContext : DbContext//IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ListingItem> ListingItems { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ListingItem>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(200);
                e.Property(e => e.Description).HasColumnType("text");
                e.Property(e => e.ExpiryDate).HasDefaultValue(DateTime.Now.AddDays(20));
                e.Property(e => e.IsUsed).HasDefaultValue(false);

                e.HasOne(i => i.Vendor).WithMany(v => v.ListingItems).HasForeignKey(i => i.VendorId);

            });
            modelBuilder.Entity<Merchant>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(200);
                e.Property(e => e.PhoneNumber).HasMaxLength(30);
                e.Property(e => e.Email).IsRequired().HasMaxLength(250);
                e.Property(e => e.Adress).HasMaxLength(300);

                e.HasMany(m => m.Reviews).WithOne(r => r.Merchant).HasForeignKey(r => r.MerchantId);
                //todo
            });
        }
    }
}
