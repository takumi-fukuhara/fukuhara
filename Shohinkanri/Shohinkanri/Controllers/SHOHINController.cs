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
    public class SHOHINController : Controller
    {
        private shohinEntities db = new shohinEntities();

        // GET: SHOHIN
        public ActionResult Index()
        {
            return View(db.SHOHIN.ToList());
        }

        // GET: SHOHIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOHIN sHOHIN = db.SHOHIN.Find(id);
            if (sHOHIN == null)
            {
                return HttpNotFound();
            }
            return View(sHOHIN);
        }

        // GET: SHOHIN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SHOHIN/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,PRICE,Update_DATE")] SHOHIN sHOHIN)
        {
            if (ModelState.IsValid)
            {
                
                db.SHOHIN.Add(sHOHIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHOHIN);
        }

        // GET: SHOHIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOHIN sHOHIN = db.SHOHIN.Find(id);
            if (sHOHIN == null)
            {
                return HttpNotFound();
            }
            return View(sHOHIN);
        }

        // POST: SHOHIN/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "ID,NAME,PRICE,Update_DATE")] SHOHIN sHOHIN)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(sHOHIN).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(sHOHIN);
         } 

       /* public ActionResult Edit([Bind(Include = "ID,NAME,PRICE,Update_DATE")] SHOHIN sHOHIN, int? id)
        {
            if (ModelState.IsValid)
            {



                SHOHIN sHOHIN2 = db.SHOHIN.Find(id);
                db.Entry(sHOHIN).State = EntityState.Modified;
                sHOHIN.NAME = sHOHIN2.NAME;
                sHOHIN.PRICE = sHOHIN2.PRICE;



                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHOHIN);
        }*/

        // GET: SHOHIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOHIN sHOHIN = db.SHOHIN.Find(id);
            if (sHOHIN == null)
            {
                return HttpNotFound();
            }
            return View(sHOHIN);
        }

        // POST: SHOHIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOHIN sHOHIN = db.SHOHIN.Find(id);
            db.SHOHIN.Remove(sHOHIN);
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
