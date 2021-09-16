using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FCSE_IT_Project.Models;

namespace FCSE_IT_Project.Controllers
{
    public class tmpProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tmpProducts
        public ActionResult Index()
        {
            return View(db.tmpProducts.ToList());
        }

        // GET: tmpProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tmpProduct tmpProduct = db.tmpProducts.Find(id);
            if (tmpProduct == null)
            {
                return HttpNotFound();
            }
            return View(tmpProduct);
        }

        // GET: tmpProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tmpProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OrderID,name,quantity,price")] tmpProduct tmpProduct)
        {
            if (ModelState.IsValid)
            {
                db.tmpProducts.Add(tmpProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tmpProduct);
        }

        // GET: tmpProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tmpProduct tmpProduct = db.tmpProducts.Find(id);
            if (tmpProduct == null)
            {
                return HttpNotFound();
            }
            return View(tmpProduct);
        }

        // POST: tmpProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OrderID,name,quantity,price")] tmpProduct tmpProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmpProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tmpProduct);
        }

        // GET: tmpProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tmpProduct tmpProduct = db.tmpProducts.Find(id);
            if (tmpProduct == null)
            {
                return HttpNotFound();
            }
            return View(tmpProduct);
        }

        // POST: tmpProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tmpProduct tmpProduct = db.tmpProducts.Find(id);
            db.tmpProducts.Remove(tmpProduct);
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
