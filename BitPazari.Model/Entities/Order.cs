using System.Collections.Generic;
using BitPazari.Core.Entity;

namespace BitPazari.Model.Entities
{
  public  class Order:CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public bool Confirmed { get; set; }
        public int AppUserID { get; set; }
        public  AppUser AppUser { get; set; }

        public  List<OrderDetail> OrderDetails { get; set; }
    }
}
