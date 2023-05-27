using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repositor.SeedData;
using WebAPI.Repository.Configurations;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.EF
{
    public class MyContext : IdentityDbContext<User, Role, int>
    { 
        public MyContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim").HasKey(x => x.UserId);
            //modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRole").HasKey(x => new { x.UserId, x.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin").HasKey(x => x.UserId);
            //modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim").HasKey(x => x.RoleId);
            //modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserToken").HasKey(x => x.UserId);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        #endregion
    }
}
