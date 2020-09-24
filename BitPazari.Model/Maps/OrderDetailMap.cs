using BitPazari.Core.Map;
using BitPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Model.Maps
{
   public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            HasKey(x => new { x.OrderID, x.ProductID });

            
        }
    }
}
