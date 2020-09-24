using BitPazari.Core.Map;
using BitPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Model.Maps
{
   public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");
            HasRequired(o => o.AppUser).
                WithMany(a => a.Orders).
                HasForeignKey(o => o.AppUserID).
                WillCascadeOnDelete(false);
        }
    }
}
