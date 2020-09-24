using BitPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitPazari.WebUI.Models
{
    public class CartItem:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal SubTotal { get { return Price * Amount; } }
    }
}