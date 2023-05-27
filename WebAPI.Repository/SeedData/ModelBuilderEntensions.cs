using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Enums;

namespace WebAPI.Repositor.SeedData
{
    public static class ModelBuilderEntensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Adminstrator Role",
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "user",
                NormalizedName = "user",
                Description = "User Role",
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "dinhson",
                NormalizedUserName = "dinhson",
                Email = "dinhson14399@gmail.com",
                NormalizedEmail = "dinhson14399@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Haquyet0508@"),
                SecurityStamp = string.Empty,
                FirstName = "Dinh",
                LastName = "Son",
                Dob = new DateTime(1999, 03, 14),
                Address = "Hcm city",
                Status = Status.Active
            }); ;

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
        }
    }
}