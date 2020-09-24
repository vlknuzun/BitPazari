using BitPazari.Core.Map;
using BitPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Model.Maps
{
   public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.Name).IsRequired().HasMaxLength(80);
            Property(x => x.Price).IsRequired().HasColumnType("money");
            Property(x=>x.UnitsInStock).IsRequired();
            Property(x => x.ImagePath).IsOptional().HasMaxLength(256);
            
            HasRequired(p => p.SubCategory).
                WithMany(s => s.Products).
                HasForeignKey(p => p.SubCategoryID).
                WillCascadeOnDelete(false);

   
            

        }

    }
}
