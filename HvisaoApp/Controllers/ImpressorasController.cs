using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HvisaoApp.Models;

namespace HvisaoApp.Controllers
{
    public class ImpressorasController : Controller
    {
        private GestorAtivosEntities db = new GestorAtivosEntities();

        // GET: Impressoras
        public ActionResult Index()
        {
            var impressora = db.Impressora.Include(i => i.Estacao);
            return View(impressora.ToList());
        }

        // GET: Impressoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impressora impressora = db.Impressora.Find(id);
            if (impressora == null)
            {
                return HttpNotFound();
            }
            return View(impressora);
        }

        // GET: Impressoras/Create
        public ActionResult Create()
        {
            ViewBag.EstacaoId = new SelectList(db.Estacao, "EstacaoId", "Hostname");
            return View();
        }

        // POST: Impressoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImpressoraId,Marca,Modelo,Monocromatica,Colorida,Nome,Setor,EnderecoIp,EstacaoId,Ativo")] Impressora impressora)
        {
            if (ModelState.IsValid)
            {
                db.Impressora.Add(impressora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstacaoId = new SelectList(db.Estacao, "EstacaoId", "Hostname", impressora.EstacaoId);
            return View(impressora);
        }

        // GET: Impressoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impressora impressora = db.Impressora.Find(id);
            if (impressora == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstacaoId = new SelectList(db.Estacao, "EstacaoId", "Hostname", impressora.EstacaoId);
            return View(impressora);
        }

        // POST: Impressoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImpressoraId,Marca,Modelo,Monocromatica,Colorida,Nome,Setor,EnderecoIp,EstacaoId,Ativo")] Impressora impressora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impressora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstacaoId = new SelectList(db.Estacao, "EstacaoId", "Hostname", impressora.EstacaoId);
            return View(impressora);
        }

        // GET: Impressoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impressora impressora = db.Impressora.Find(id);
            if (impressora == null)
            {
                return HttpNotFound();
            }
            return View(impressora);
        }

        // POST: Impressoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Impressora impressora = db.Impressora.Find(id);
            db.Impressora.Remove(impressora);
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
