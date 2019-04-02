using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL2.Models;

namespace PBL2.Controllers
{
    public class MovelsController : Controller
    {
        private PBL2Context db = new PBL2Context();

        // GET: Movels
        public ActionResult Index()
        {
            return View(db.Movels.ToList());
        }

        // GET: Movels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Movels.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // GET: Movels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pk_Movel,Nome,Cor,Medidas,Material,Link,Status")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                db.Movels.Add(movel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movel);
        }

        // GET: Movels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Movels.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // POST: Movels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pk_Movel,Nome,Cor,Medidas,Material,Link,Status")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movel);
        }

        // GET: Movels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Movels.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // POST: Movels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movel movel = db.Movels.Find(id);
            db.Movels.Remove(movel);
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
