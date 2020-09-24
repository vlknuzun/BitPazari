using BitPazari.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitPazari.WebUI.Helpers
{
    public class CartHelper
    {
        private Dictionary<int, CartItem> _cart = null;
        public CartHelper()
        {
            _cart = new Dictionary<int, CartItem>();
        }

        public List<CartItem> CartList { get => _cart.Values.ToList(); }

        public void AddToCart(CartItem item)
        {
            if (item.Amount==0)
            {
                RemoveCart(item.Id);
                return;
            }

            if (_cart.ContainsKey(item.Id))
            {
                _cart[item.Id].Amount += item.Amount;
                return;
            }
            _cart.Add(item.Id, item);
        }
        public void RemoveCart(int id)
        {
            _cart.Remove(id);
        }

        public void IncreaseCart(int id)
        {
            _cart[id].Amount += 1;
        }
        public void DecreaseCart(int id)
        {
            _cart[id].Amount -= 1;
            if (_cart[id].Amount<=0)
            {
                RemoveCart(id);
            }
        }
    }
}