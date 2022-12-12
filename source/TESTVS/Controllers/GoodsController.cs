using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TESTVS.Models;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;

namespace TESTVS.Controllers
{
    public class GoodsController : Controller
    {
        public static List<Good> goodlist = new List<Good>();

        private WEBMVCEntities1 db = new WEBMVCEntities1();

        // GET: Goods
        public ActionResult Index()
        {
            var goods = db.Goods.Include(g => g.Manufacturer);
            return View(goods.ToList());
        }

        // GET: Goods/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName");
            ViewBag.GoodsId = new SelectList(db.Imports, "GoodsId", "AccountantId");
            ViewBag.GoodsId = new SelectList(db.Orders, "GoodsId", "AgentId");
            ViewBag.GoodsId = new SelectList(db.warehouses, "GoodsId", "GoodsId");
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsId,GoodsUnit,GoodsName,GoodsPrice,ManufacturerID")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(good);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", good.ManufacturerID);
            ViewBag.GoodsId = new SelectList(db.Imports, "GoodsId", "AccountantId", good.GoodsId);
            ViewBag.GoodsId = new SelectList(db.Orders, "GoodsId", "AgentId", good.GoodsId);
            ViewBag.GoodsId = new SelectList(db.warehouses, "GoodsId", "GoodsId", good.GoodsId);
            return View(good);
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", good.ManufacturerID);
            ViewBag.GoodsId = new SelectList(db.Imports, "GoodsId", "AccountantId", good.GoodsId);
            ViewBag.GoodsId = new SelectList(db.Orders, "GoodsId", "AgentId", good.GoodsId);
            ViewBag.GoodsId = new SelectList(db.warehouses, "GoodsId", "GoodsId", good.GoodsId);
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsId,GoodsUnit,GoodsName,GoodsPrice,ManufacturerID")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Entry(good).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", good.ManufacturerID);
            ViewBag.GoodsId = new SelectList(db.Imports, "GoodsId", "AccountantId", good.GoodsId);
            ViewBag.GoodsId = new SelectList(db.Orders, "GoodsId", "AgentId", good.GoodsId);
            ViewBag.GoodsId = new SelectList(db.warehouses, "GoodsId", "GoodsId", good.GoodsId);
            return View(good);
        }

        public ActionResult Cart()
        {
            return View(goodlist);
        }

        public ActionResult AddCart(string id, string unit)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id, unit);
            if (good == null)
            {
                return HttpNotFound();
            }
            bool exist = goodlist.Any(x => x.GoodsId == good.GoodsId && x.GoodsUnit == good.GoodsUnit);
            if (exist == false)
            {
                goodlist.Add(good);
                return View(goodlist);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Order(string id, string unit)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id, unit);
            if (good == null)
            {
                return HttpNotFound();
            }
            Order o = new Order();
            o.GoodsId = good.GoodsId;
            o.GoodsUnit = good.GoodsUnit;
            return View(o);
        }

        [HttpPost]
        public ActionResult Order(Order o)
        {
            if (o.Quantity <= 0)
            {
                return View(o);
            }

           warehouse wh = db.warehouses.Find(o.GoodsId, o.GoodsUnit);
           if (wh != null)
           {
                if (o.Quantity > wh.Quantity)
                {
                    return View(o);
                }
           }
            return RedirectToAction("EnterAgent",o);
        }

        public ActionResult EnterAgent(Order o)
        {
            //Enter agent id, agent password to confirm order 
            return View(o); 
        }

        [HttpPost]
        public ActionResult ConfirmOrder(Order o)
        {
            o.OrderDate = DateTime.Today;
            Agent a = db.Agents.Find(o.AgentId);
            if (a == null)
            {
                return RedirectToAction("Create", "Agents");
            }

            if (a.AgentPassword != o.AgentPassword)
            {
                return RedirectToAction("EnterAgent", o);
            }

            string stringConnection = @"Data Source=DESKTOP-P5A8F2J\SQLEXPRESS;Initial Catalog=WEBMVC; Integrated Security=True";
            SqlConnection con = new SqlConnection(stringConnection);
            SqlCommand sqlCommand;

            String query_updateWarehouse = "update warehouse set Quantity=Quantity-@Quantity where GoodsId=@goodsId and GoodsUnit = @goodsUnit";
            String query_updatePriceQuantity = "update Orders set Quantity=Quantity+@Quantity,TotalPrice=TotalPrice+@TotalPrice where GoodsId=@goodsId and GoodsUnit = @goodsUnit and OrderDate=@OrderDate and AgentId=@AgentId";
            Good g = db.Goods.Find(o.GoodsId, o.GoodsUnit);

            g = db.Goods.Find(o.GoodsId, o.GoodsUnit);
            //o.TotalPrice = g.GoodsPrice * o.Quantity;
            //o.deliveryState = "undelivered";
            //o.OrderDate = DateTime.Today;
            //db.Orders.Add(o);
            //db.SaveChanges();

            if (g == null)
            {
                return HttpNotFound();
            }
            bool exist = db.Orders.Any(x => x.GoodsId == o.GoodsId && x.GoodsUnit == o.GoodsUnit && x.AgentId == o.AgentId && x.OrderDate == o.OrderDate);
           
            Order temp = db.Orders.Find(o.AgentId,o.GoodsId,o.GoodsUnit,o.OrderDate);
            if (temp != null)
            {
                
                con.Open();
                
                sqlCommand = new SqlCommand(query_updatePriceQuantity, con);
                sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = o.Quantity;
                sqlCommand.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = g.GoodsPrice * o.Quantity;
                sqlCommand.Parameters.Add("@OrderDate", SqlDbType.Date).Value = o.OrderDate;
                sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = o.GoodsId;
                sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = o.GoodsUnit;
                sqlCommand.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = o.AgentId;
                sqlCommand.ExecuteReader();

                // update bảng warehouse
                con.Close();
                con.Open();

                sqlCommand = new SqlCommand(query_updateWarehouse, con);
                sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = o.GoodsId;
                sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = o.GoodsUnit;
                sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = o.Quantity;
                sqlCommand.ExecuteNonQuery();

                con.Close();
                return RedirectToAction("Index", "Orders");
            }
          
            o.TotalPrice = g.GoodsPrice * o.Quantity;
            o.deliveryState = "undelivered";
            o.OrderDate = DateTime.Today;
            db.Orders.Add(o);
            db.SaveChanges();

            con.Open();
            sqlCommand = new SqlCommand(query_updateWarehouse, con);
            sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = o.GoodsId;
            sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = o.GoodsUnit;
            sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = o.Quantity;
            sqlCommand.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index","Orders");
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(string id, string unit)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id, unit);
            
            if (good == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string unit)
        {
            Good good = db.Goods.Find(id, unit);
            if (good != null)
            {
                db.Goods.Remove(good);
                db.SaveChanges();
            }
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
