using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW6_v2.Models;
using PagedList.Mvc;
using PagedList;

namespace HW6_v2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Orders
        private BikeStoresEntities db = new BikeStoresEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {
            List<OrdersViewModel> order = db.order_items.Select(p => new OrdersViewModel { OrderID = p.order_id, Category = p.product.category.category_name, ProdName = db.products.Where(x => x.product_id == p.product_id).FirstOrDefault(), Quantity = p.quantity, Price = p.list_price, Total = (p.list_price * p.quantity), Date = db.orders.Where(o => o.order_id == p.order_id).FirstOrDefault().order_date }).ToList();
            return View(order);
        }
        public ActionResult Search(DateTime date)
        {
            string searchdate = date.ToShortDateString();
            List<OrdersViewModel> order = db.order_items.Where(y => y.order.order_date <= date).Select(p => new OrdersViewModel { OrderID = p.order_id, Category = p.product.category.category_name, ProdName = db.products.Where(x => x.product_id == p.product_id).FirstOrDefault(), Quantity = p.quantity, Price = p.list_price, Total = (p.list_price * p.quantity), Date = db.orders.Where(o => o.order_id == p.order_id).FirstOrDefault().order_date }).ToList();
            return View("Orders", order);
        }
        public ActionResult Paging(int? page)
        {
            List<OrdersViewModel> order = db.order_items.Select(p => new OrdersViewModel { OrderID = p.order_id, Category = p.product.category.category_name, ProdName = db.products.Where(x => x.product_id == p.product_id).FirstOrDefault(), Quantity = p.quantity, Price = p.list_price, Total = (p.list_price * p.quantity), Date = db.orders.Where(o => o.order_id == p.order_id).FirstOrDefault().order_date }).ToList();

            return View("Orders", db.order_items.OrderBy(o => o.item_id).ToPagedList(page ?? 1, 10));
        }
             
        public ActionResult Reports()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}