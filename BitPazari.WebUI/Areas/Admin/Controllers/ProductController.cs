using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitPazari.Model.Context;
using BitPazari.Model.Entities;
using BitPazari.WebUI.Helpers;

namespace BitPazari.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.SubCategory);
            return View(products.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Add()
        {
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "Id", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add( Product product,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image==null)
                {
                    return View(product);
                }
                var resimyuklemesonucu = ImageUploadHelper.UploadSingleImage("~/Updolads/", image);
                if (resimyuklemesonucu=="0"||resimyuklemesonucu=="1"||resimyuklemesonucu=="2")
                {
                    //1.yol default bir resim ekleme;
                    //2.yol hata verme;
                }
                else
                {
                    product.ImagePath = resimyuklemesonucu.Split('/')[2];
                }


                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "Id", "Name", product.SubCategoryID);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "Id", "Name", product.SubCategoryID);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Price,UnitsInStock,Name,ImagePath,SubCategoryID,MasterID,Status,CreatedDate,CreatedComputerName,CreatedIp,CreatedUserName,CreatedBy,ModifiedDate,ModifiedComputerName,ModifiedIp,ModifiedUserName,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "Id", "Name", product.SubCategoryID);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
