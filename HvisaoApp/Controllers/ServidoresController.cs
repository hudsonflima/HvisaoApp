﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HvisaoApp.Models;

namespace HvisaoApp.Controllers
{
    public class ServidoresController : Controller
    {
        private GestorAtivosEntities db = new GestorAtivosEntities();

        // GET: Servidores
        public ActionResult Index()
        {
            return View(db.Servidor.ToList());
        }

        // GET: Servidores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servidor servidor = db.Servidor.Find(id);
            if (servidor == null)
            {
                return HttpNotFound();
            }
            return View(servidor);
        }

        // GET: Servidores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servidores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServidorId,Hostname,Funcao,EnderecoIp,SistemaOperacional,ChavedeAtivacao")] Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                db.Servidor.Add(servidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servidor);
        }

        // GET: Servidores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servidor servidor = db.Servidor.Find(id);
            if (servidor == null)
            {
                return HttpNotFound();
            }
            return View(servidor);
        }

        // POST: Servidores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServidorId,Hostname,Funcao,EnderecoIp,SistemaOperacional,ChavedeAtivacao")] Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servidor);
        }

        // GET: Servidores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servidor servidor = db.Servidor.Find(id);
            if (servidor == null)
            {
                return HttpNotFound();
            }
            return View(servidor);
        }

        // POST: Servidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servidor servidor = db.Servidor.Find(id);
            db.Servidor.Remove(servidor);
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
