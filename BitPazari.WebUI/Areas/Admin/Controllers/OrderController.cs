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

namespace BitPazari.WebUI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.AppUser);
            return View(orders.ToList());
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.AppUserID = new SelectList(db.UsersTable, "Id", "Name");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Confirmed,AppUserID,MasterID,Status,CreatedDate,CreatedComputerName,CreatedIp,CreatedUserName,CreatedBy,ModifiedDate,ModifiedComputerName,ModifiedIp,ModifiedUserName,ModifiedBy")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppUserID = new SelectList(db.UsersTable, "Id", "Name", order.AppUserID);
            return View(order);
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppUserID = new SelectList(db.UsersTable, "Id", "Name", order.AppUserID);
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Confirmed,AppUserID,MasterID,Status,CreatedDate,CreatedComputerName,CreatedIp,CreatedUserName,CreatedBy,ModifiedDate,ModifiedComputerName,ModifiedIp,ModifiedUserName,ModifiedBy")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppUserID = new SelectList(db.UsersTable, "Id", "Name", order.AppUserID);
            return View(order);
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
