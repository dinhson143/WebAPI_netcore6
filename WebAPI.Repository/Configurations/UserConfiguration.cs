using WebAPI.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Repository.Enums;

namespace WebAPI.Repository.Configurations
{
    /// <summary>
    /// This class store configurations of Lesson domain class for fluent API
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(a => a.FirstName).HasColumnType("nvarchar(255)");
            builder.Property(a => a.LastName).HasColumnType("nvarchar(255)");
            builder.Property(a => a.Status).HasDefaultValue(Status.Active);
        }
    }
}
