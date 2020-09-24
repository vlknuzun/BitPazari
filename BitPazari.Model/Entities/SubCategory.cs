using System.Collections.Generic;
using BitPazari.Core.Entity;

namespace BitPazari.Model.Entities
{
   public class SubCategory:CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Tag { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public  List<Product> Products { get; set; }
    }
}
