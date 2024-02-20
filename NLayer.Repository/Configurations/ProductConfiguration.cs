using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.Name).HasMaxLength(200).IsRequired();

            // 1234567891234567.12 toplam 18 rakamlı fiyatı olabilir.
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Products");

            //1 product'ın 1 kategorisi   1 kategorininde çok products'ı olabilir.
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
