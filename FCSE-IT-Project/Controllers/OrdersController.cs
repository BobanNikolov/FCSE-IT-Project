using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using FCSE_IT_Project.Models;
using FCSE_IT_Project.Repositories;

namespace FCSE_IT_Project.Controllers
{
    [Authorize(Roles ="Manager, Waiter")]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Dictionary<Order, List<tmpProduct>> orderProducts = new Dictionary<Order, List<tmpProduct>>();


        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
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

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        [Authorize(Roles = "Waiter,Manager")]
        // GET: Orders/Edit/5
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
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        [Authorize(Roles = "Waiter,Manager")]
        // GET: Orders/AddProductsToOrder/5
        public ActionResult AddProductsToOrder(int? id)
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
            ProductsRepository objordersRepository = new ProductsRepository();
            var objModels = new Tuple<IEnumerable<SelectListItem>, Order>(objordersRepository.GetAllProducts(), order);
            return View(objModels);
        }

        // POST: Orders/AddProductsToOrder
        [HttpPost]
        public ActionResult AddProductsToOrder(string products)
        {
            var js = new JavaScriptSerializer();
            if (products != null)
            {
                tmpProduct[] tmpProducts = js.Deserialize<tmpProduct[]>(products);
                List<tmpProduct> productsToWorkWith = tmpProducts.ToList();
                Order order = db.Orders.Find(productsToWorkWith[0].OrderID);
                order.order = productsToWorkWith;
                ProductsRepository objordersRepository = new ProductsRepository();
                var objModels = new Tuple<IEnumerable<SelectListItem>, Order>(objordersRepository.GetAllProducts(), order);
                return View(objModels);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult getProductPrice(int productId)
        {
            int productPrice = db.Products.Single(model => model.Id == productId).Price;
            return Json(productPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getProducts(int orderId)
        {
            Order order = db.Orders.Find(orderId);
            var products = new List<tmpProduct>();
            if (!orderProducts.ContainsKey(order))
            {
                orderProducts.Add(order, new List<tmpProduct>());
                products = orderProducts[order];
            }
            else
            {
                products = orderProducts[order];
            }
            var productsToReturn = new JavaScriptSerializer().Serialize(products);
            return Json(productsToReturn, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Manager")]
        // GET: Orders/Delete/5
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

        // POST: Orders/Delete/5
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
