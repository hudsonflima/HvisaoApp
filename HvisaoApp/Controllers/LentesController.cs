﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HvisaoApp.Models;

namespace HvisaoApp.Controllers
{
    public class LentesController : Controller
    {
        private BancoContexto db = new BancoContexto();

        // GET: Lentes
        public ActionResult Index()
        {
            return View(db.Lentes.ToList());
        }

        // GET: Lentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lentes lentes = db.Lentes.Find(id);
            if (lentes == null)
            {
                return HttpNotFound();
            }
            return View(lentes);
        }

        // GET: Lentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolicitacaoId,Registro,Paciente,Descricao,DataPedido,Entregue")] Lentes lentes)
        {
            if (ModelState.IsValid)
            {
                db.Lentes.Add(lentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lentes);
        }

        // GET: Lentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lentes lentes = db.Lentes.Find(id);
            if (lentes == null)
            {
                return HttpNotFound();
            }
            return View(lentes);
        }

        // POST: Lentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SolicitacaoId,Registro,Paciente,Descricao,DataPedido,Entregue")] Lentes lentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lentes);
        }

        // GET: Lentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lentes lentes = db.Lentes.Find(id);
            if (lentes == null)
            {
                return HttpNotFound();
            }
            return View(lentes);
        }

        // POST: Lentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lentes lentes = db.Lentes.Find(id);
            db.Lentes.Remove(lentes);
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
