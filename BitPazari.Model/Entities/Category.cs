using System.Collections.Generic;
using BitPazari.Core.Entity;
namespace BitPazari.Model.Entities
{
    public class Category:CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  virtual List<SubCategory> SubCategories { get; set; }

    }
}
