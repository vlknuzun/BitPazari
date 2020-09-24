using BitPazari.Core.Entity.Enum;
using BitPazari.Model.Entities;
using BitPazari.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPazari.Service.Option
{
   public class OrderService:BaseService<Order>
    {
        public List<Order> ListPendingOrders()
        {
            return GetDefault(x => x.Confirmed == false && x.Status == Status.Active).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int PendingOrderCount()
        {
            return GetDefault(x => x.Confirmed == false && x.Status == Status.Active).Count;
        }
    }
}
