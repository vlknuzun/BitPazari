using BitPazari.Model.Entities;
using BitPazari.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitPazari.WebUI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {

        SubCategoryService _subCategoryService;
        CategoryService _categoryService;

        public SubCategoryController()
        {
            _subCategoryService = new SubCategoryService();
            _categoryService = new CategoryService();
        }

        // GET: Admin/SubCategory
        public ActionResult Index()
        {
            var subCategories = _subCategoryService.GetActive();
            if (subCategories==null)
            {
                ViewBag.Error = "Liste Yüklenemedi...";
                return View();
            }
            if (subCategories.Count <= 0)
            {
                ViewBag.Information = "Listede Gösterilecek Veri Bulunmuyor...";
                return View();
            }


            return View(subCategories);
        }


        public ActionResult Add()
        {
            ViewBag.CategoryList = _categoryService.GetActive();
            return View();
        }
        [HttpPost]
        public ActionResult Add(SubCategory item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _subCategoryService.Add(item);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            ViewBag.CategoryList = _categoryService.GetActive();
            return View(_subCategoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(SubCategory item)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            _subCategoryService.Update(item);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            _subCategoryService.Remove(_subCategoryService.GetById(id));
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            
            return View(_subCategoryService.GetById(id));
        }
    }
}