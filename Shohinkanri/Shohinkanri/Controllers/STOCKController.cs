using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shohinkanri.Models;

namespace Shohinkanri.Controllers
{
    public class STOCKController : Controller
    {
        private shohinEntities db = new shohinEntities();

        // GET: STOCK
        public ActionResult Index()
        {
            return View(db.STOCK.ToList());
        }

        // GET: STOCK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return HttpNotFound();
            }
            return View(sTOCK);
        }

        // GET: STOCK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STOCK/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,PRICE,QUANTITY,TOTAL_AMOUNT,Update_Date")] STOCK sTOCK)
        {
            if (ModelState.IsValid)
            {
                db.STOCK.Add(sTOCK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTOCK);
        }

        // GET: STOCK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return HttpNotFound();
            }
            return View(sTOCK);
        }

        // POST: STOCK/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,PRICE,QUANTITY,TOTAL_AMOUNT,Update_Date")] STOCK sTOCK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTOCK).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTOCK);
        }

        // GET: STOCK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOCK sTOCK = db.STOCK.Find(id);
            if (sTOCK == null)
            {
                return HttpNotFound();
            }
            return View(sTOCK);
        }

        // POST: STOCK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STOCK sTOCK = db.STOCK.Find(id);
            db.STOCK.Remove(sTOCK);
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
