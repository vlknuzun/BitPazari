using BitPazari.Core.Entity;

namespace BitPazari.Model.Entities
{
    public class OrderDetail:CoreEntity
    {
        public int ProductID { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
        public int OrderID { get; set; }

        public  Product Product { get; set; }
        public  Order Order { get; set; }
    }
}
