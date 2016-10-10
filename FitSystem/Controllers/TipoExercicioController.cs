using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitSystem.Models;

namespace FitSystem.Controllers
{
    public class TipoExercicioController : Controller
    {
        private BDContext db = new BDContext();

        // GET: TipoExercicio
        public ActionResult Index()
        {
            return View(db.TipoExercicio.ToList());
        }

        // GET: TipoExercicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoExercicio tipoExercicio = db.TipoExercicio.Find(id);
            if (tipoExercicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoExercicio);
        }

        // GET: TipoExercicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoExercicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoExercicioId,TipoExercicioDesc")] TipoExercicio tipoExercicio)
        {
            if (ModelState.IsValid)
            {
                db.TipoExercicio.Add(tipoExercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoExercicio);
        }

        // GET: TipoExercicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoExercicio tipoExercicio = db.TipoExercicio.Find(id);
            if (tipoExercicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoExercicio);
        }

        // POST: TipoExercicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoExercicioId,TipoExercicioDesc")] TipoExercicio tipoExercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoExercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoExercicio);
        }

        // GET: TipoExercicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoExercicio tipoExercicio = db.TipoExercicio.Find(id);
            if (tipoExercicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoExercicio);
        }

        // POST: TipoExercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoExercicio tipoExercicio = db.TipoExercicio.Find(id);
            db.TipoExercicio.Remove(tipoExercicio);
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
