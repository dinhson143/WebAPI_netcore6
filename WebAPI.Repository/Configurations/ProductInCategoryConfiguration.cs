using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Entities;

namespace WebAPI.Repository.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(x => new { x.CategoryId, x.ProductId });

            // Many to Many: Category - Product
            builder.HasOne(x => x.Product).WithMany(y => y.ProductInCategories).HasForeignKey(y => y.ProductId);

            builder.HasOne(x => x.Category).WithMany(y => y.ProductInCategories).HasForeignKey(y => y.CategoryId);
        }
    }
}