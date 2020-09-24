using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitPazari.Core.Map;

namespace BitPazari.Model.Maps
{
    using Entities;
  public  class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            Property(x => x.Description).IsOptional().HasMaxLength(300);

            HasMany(x => x.SubCategories).WithRequired(x => x.Category).HasForeignKey(x=>x.CategoryID);
        }
    }
}
