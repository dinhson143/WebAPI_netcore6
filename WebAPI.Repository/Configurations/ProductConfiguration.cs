﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.Stock).HasDefaultValue(0);
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Image).HasDefaultValue("bit.ly/3oxcpRi");
        }
    }
}
