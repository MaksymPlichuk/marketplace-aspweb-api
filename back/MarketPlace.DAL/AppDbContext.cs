using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL
{
    public class AppDbContext : IdentityDbContext<AppUserEntity, AppRoleEntity, string, AppUserClaimEntity, AppUserRoleEntity,
                                                        AppUserLoginEntity, AppRoleClaimEntity, AppUserTokenEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ItemCategoryEntity> ItemCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(200);
                e.Property(e => e.Description).HasColumnType("text");
                e.Property(e => e.Price).HasDefaultValue(0);
                e.Property(e => e.Quantity).HasDefaultValue(1);
                //e.Property(e => e.ListingExpiryDate).HasDefaultValue(DateTime.UtcNow.AddDays(20));
                e.Property(e => e.IsUsed).HasDefaultValue(false);
                e.Property(e => e.IsSoldOut).HasDefaultValue(false);
                e.Property(e => e.Image).HasMaxLength(500);


                e.HasMany(i => i.Orders).WithMany(o => o.Items).UsingEntity("ItemOrders");
                e.HasMany(i => i.Reviews).WithOne(r => r.Item).HasForeignKey(r => r.ItemId);
                e.HasOne(i => i.Seller).WithMany(s => s.SellingItems).HasForeignKey(i => i.SellerId);

            });
            modelBuilder.Entity<ReviewEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Title).IsRequired().HasMaxLength(255);
                e.Property(e => e.Description).IsRequired().HasColumnType("text");
                e.Property(e => e.Rating).HasDefaultValue(0f);

                e.HasOne(r => r.Author).WithMany(a => a.Reviews).HasForeignKey(r => r.AuthorId);
            });
            modelBuilder.Entity<OrderEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.FinalPrice).HasDefaultValue(0d);
                e.Property(e => e.OrderStatus).HasDefaultValue("Pending");

                e.HasOne(e => e.Buyer).WithMany(b => b.BoughtOrders).HasForeignKey(e => e.BuyerId);
                e.HasOne(e => e.Seller).WithMany(s => s.SoldOrders).HasForeignKey(e => e.SellerId);
            });

            modelBuilder.Entity<ItemCategoryEntity>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired().HasMaxLength(150);
                e.Property(e => e.Image).HasMaxLength(500);

                e.HasMany(c => c.Items).WithOne(i => i.Category).HasForeignKey(i => i.CategoryId);
            });


        modelBuilder.Entity<AppUserEntity>(b =>
            {
                b.HasKey(b => b.Id);
                b.Property(b => b.UserName).IsRequired().HasMaxLength(50);
                b.Property(b => b.FirstName).IsRequired().HasMaxLength(50);
                b.Property(b => b.Surname).IsRequired().HasMaxLength(50);
                b.Property(b => b.MiddleName).HasMaxLength(50);
                b.Property(b => b.Address).HasColumnType("text");
                b.Property(b => b.PhoneNumber).HasMaxLength(13);
                b.Property(b => b.Image).HasMaxLength(500);
                
        // Each User can have many UserClaims
        b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<AppRoleEntity>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }
    }
}
