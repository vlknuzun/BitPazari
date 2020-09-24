using BitPazari.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitPazari.WebUI.Controllers
{

    public class ProductController:Controller
    {
        ProductService _productService;
        SubCategoryService _subCategoryService;
        public ProductController()
        {
            _productService = new ProductService();
            _subCategoryService = new SubCategoryService();
        }


        public ActionResult List(int? subcategoryid)
        {
            if (subcategoryid!=null)
            {
                var model = _productService.GetDefault(x => x.SubCategoryID == subcategoryid);
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail(int? id)
        {
            if (id!=null)
            {
                var entity = _productService.GetById((int)id);
                return View(entity);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}