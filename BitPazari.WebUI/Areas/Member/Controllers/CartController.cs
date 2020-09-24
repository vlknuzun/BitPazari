using BitPazari.Service.Option;
using BitPazari.WebUI.Helpers;
using BitPazari.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitPazari.WebUI.Areas.Member.Controllers
{
    public class CartController : Controller
    {

        ProductService _productService;
        public CartController()
        {
            _productService = new ProductService();
        }

        // GET: Member/Cart
        //Session["cart"]
        public ActionResult Index()
        {
            return View();
      
        }

        public ActionResult List()
        {
            if (Session["cart"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var cart = Session["cart"] as CartHelper;
            
            return Json(cart.CartList,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(int id)
        {
            CartItem sepetUrunu = new CartItem();
            var urun = _productService.GetById(id);
            sepetUrunu.Id = urun.Id;
            sepetUrunu.Name = urun.Name;
            sepetUrunu.Price = Convert.ToDecimal(urun.Price);
            sepetUrunu.Amount = 1;
            var cart = Session["cart"] == null ? new CartHelper():Session["cart"] as CartHelper;
            cart.AddToCart(sepetUrunu);
            Session["cart"] = cart;
          //  return RedirectToAction("Index", "Home");//her ürün eklemede Index sayfasını yeniden çağırı.
                                                     //- Ürün eklemesi sonrasında sayfa veritabanından güncel bilgiler ile dolacağı için kişi sitede kaldığı sürece yeni ürünleri görebilir.
            return Json("");//Json döndürmenin güzel yanı sayfanız kesinlikle veritabanına gitmez ve hem trafik hemde veritabanı kullanım maliyetini azaltır. lakin güncel ürünleri göremez.
        }
    }
}