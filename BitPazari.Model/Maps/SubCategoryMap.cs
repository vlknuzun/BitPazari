using BitPazari.Core.Map;
using BitPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Model.Maps
{
   public class SubCategoryMap:CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.Description).IsOptional().HasMaxLength(300);
            Property(x => x.Tag).IsOptional();

            HasMany(sub => sub.Products)
                .WithRequired(p => p.SubCategory)
                .HasForeignKey(p => p.SubCategoryID);
        }

    }
}
