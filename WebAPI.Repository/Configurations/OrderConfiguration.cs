using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Enums;

namespace WebAPI.Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.ShipAddress).IsRequired().IsUnicode(true).HasMaxLength(200);
            builder.Property(x => x.ShipName).IsRequired().IsUnicode(true).HasMaxLength(200);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().IsUnicode(false).HasMaxLength(20);
            builder.Property(x => x.Tongtien).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.Confirmed);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
