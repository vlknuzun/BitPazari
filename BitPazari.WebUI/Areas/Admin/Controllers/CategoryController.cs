using BitPazari.Service.Option;
using BitPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitPazari.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category

        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public ActionResult Index()
        {
           var categoryList = _categoryService.GetActive();
            if (categoryList.Count==0||categoryList==null)
            {
                return RedirectToRoute("/Admin/Views/Shared/Error.cshtml");
            }

            return View(categoryList);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Add(item);
                }
                catch
                {
                    ViewBag.Error = "Ekleme İşlemi Sırasında Bir Hata Meydana Geldi. Lütfen Bilgileri Tekrar Doldurunuz.";
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Update(int id)
        {
          var guncellenecek= _categoryService.GetById(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(Category item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Update(item);
                }
                catch
                {
                    ViewBag.Error = "Güncelleme İşlemi Sırasında Bir Hata Meydana Geldi. Lütfen Bilgileri Tekrar Doldurunuz.";
                    return View();
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _categoryService.Remove(_categoryService.GetById(id));
            return RedirectToAction("Index");
        }


    }
}