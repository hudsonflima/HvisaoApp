using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HvisaoApp.Models;

namespace HvisaoApp.Controllers
{
    public class EstacoesController : Controller
    {
        private GestorAtivosEntities db = new GestorAtivosEntities();

        // GET: Estacoes
        public ActionResult Index()
        {
            return View(db.Estacao.ToList());
        }

        // GET: Estacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacao estacao = db.Estacao.Find(id);
            if (estacao == null)
            {
                return HttpNotFound();
            }
            return View(estacao);
        }

        // GET: Estacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstacaoId,Hostname,Setor,EnderecoIp,SistemaOperacional,ChavedeAtivacao,Ativo")] Estacao estacao)
        {
            if (ModelState.IsValid)
            {
                db.Estacao.Add(estacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estacao);
        }

        // GET: Estacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacao estacao = db.Estacao.Find(id);
            if (estacao == null)
            {
                return HttpNotFound();
            }
            return View(estacao);
        }

        // POST: Estacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstacaoId,Hostname,Setor,EnderecoIp,SistemaOperacional,ChavedeAtivacao,Ativo")] Estacao estacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estacao);
        }

        // GET: Estacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacao estacao = db.Estacao.Find(id);
            if (estacao == null)
            {
                return HttpNotFound();
            }
            return View(estacao);
        }

        // POST: Estacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estacao estacao = db.Estacao.Find(id);
            db.Estacao.Remove(estacao);
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
