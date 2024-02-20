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
    //Entitylerimizi konfigüre ettiğimiz sınıflarda bu arayüz implemente edilmelidir.
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); // Id alanı prim. key oldu
            
            //Id alanını Identity column olarak kullan
            builder.Property(x => x.Id).UseIdentityColumn();

            //Name propu max 50 karakter alsın ve boş geçilemez olsun. Yani nullable olmasın dbde
            builder.Property(x=> x.Name).HasMaxLength(50).IsRequired();

            //Db de oluşacak tablonun adını buradan değiştirebilirsin.
            builder.ToTable("Categories");
        }
    }
}
