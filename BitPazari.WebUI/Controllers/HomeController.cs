using BitPazari.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitPazari.WebUI.Controllers
{
    public class HomeController : Controller
    {
        CategoryService _categoryService;
        ProductService _productService;
        public HomeController()
        {
            _categoryService = new CategoryService();
            _productService = new ProductService();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        //Action döndürmeyen normal metotlarımızın yine tarayıcıdan erişilebilir olma durumları olduğu için NonAction attribute'ünü ekleyip tayıcı Url kısmından eişilmesini engelleriz.
        //[NonAction]

        //Bu metot PartialView'i yönlendirmek için kullanılıyor. ChildActionOnly bu action'ın sadece program içerisinden çağırılabileceğini belirtir.Opsiyoneldir... yani tarayıcı browserından erişilmeyi engeller.
        [ChildActionOnly]
        public ActionResult CategoryList()
        {

            return PartialView("_CategoryList",_categoryService.GetActive());
        }
        [ChildActionOnly]

        public ActionResult ProductList()
        {
            return PartialView("_ProductList", _productService.GetActive().OrderByDescending(x => x.CreatedDate).Take(9).ToList());
        }
    }
}