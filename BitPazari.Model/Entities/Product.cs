using System.Collections.Generic;
using BitPazari.Core.Entity;

namespace BitPazari.Model.Entities
{
   public class Product:CoreEntity
    {
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int SubCategoryID { get; set; }
        public  SubCategory SubCategory { get; set; }
        public  List<OrderDetail> OrderDetails { get; set; }

    }
}
