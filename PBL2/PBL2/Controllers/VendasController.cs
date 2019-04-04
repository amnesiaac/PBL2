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
    public class VendasController : Controller
    {
        private PBL2Context db = new PBL2Context();

        // GET: Vendas
        public ActionResult Index()
        {
            var vendas = db.Vendas.Include(v => v.Funcionario).Include(v => v.Movel);
            return View(vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Funcionario = new SelectList(db.Funcionarios, "Pk_Funcionario", "Nome");
            ViewBag.Fk_Movel = new SelectList(db.Movels, "Pk_Movel", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pk_Venda,Fk_Funcionario,Fk_Movel")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = db.Funcionarios.Find(venda.Fk_Funcionario);
                venda.Funcionario = funcionario;
                Movel movel = db.Movels.Find(venda.Fk_Movel);
                venda.Movel = movel;
                if (venda.mudastatusFuncionario()) {
                    db.Vendas.Add(venda);
                    db.SaveChanges();
                    funcionario.Status = "indisponivel";
                    db.Entry(funcionario).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (venda.mudastatusMovel())
                {
                    db.Vendas.Add(venda);
                    db.SaveChanges();
                    movel.Status = "Em construção";
                    db.Entry(movel).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Funcionario = new SelectList(db.Funcionarios, "Pk_Funcionario", "Nome", venda.Fk_Funcionario);
            ViewBag.Fk_Movel = new SelectList(db.Movels, "Pk_Movel", "Nome", venda.Fk_Movel);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Funcionario = new SelectList(db.Funcionarios, "Pk_Funcionario", "Nome", venda.Fk_Funcionario);
            ViewBag.Fk_Movel = new SelectList(db.Movels, "Pk_Movel", "Nome", venda.Fk_Movel);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pk_Venda,Fk_Funcionario,Fk_Movel")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Funcionario = new SelectList(db.Funcionarios, "Pk_Funcionario", "Nome", venda.Fk_Funcionario);
            ViewBag.Fk_Movel = new SelectList(db.Movels, "Pk_Movel", "Nome", venda.Fk_Movel);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
            db.SaveChanges();
            Funcionario funcionario = db.Funcionarios.Find(venda.Fk_Funcionario);
            venda.Funcionario = funcionario;
            Movel movel = db.Movels.Find(venda.Fk_Movel);
            venda.Movel = movel;
            if (!venda.mudastatusFuncionario())
            {
                funcionario.Status = "Disponivel";
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (!venda.mudastatusMovel())
            {
                movel.Status = "Entregue";
                db.Entry(movel).State = EntityState.Modified;
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
