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
    public class ExercicioController : Controller
    {
        private BDContext db = new BDContext();

        // GET: Exercicio
        public ActionResult Index()
        {
            var exercicio = db.Exercicio.Include(e => e.TipoExercicio);
            return View(exercicio.ToList());
        }

        // GET: Exercicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicio.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // GET: Exercicio/Create
        public ActionResult Create()
        {
            ViewBag.TipoExercicioId = new SelectList(db.TipoExercicio, "TipoExercicioId", "TipoExercicioDesc");
            return View();
        }

        // POST: Exercicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExercicioId,ExercicioDesc,TipoExercicioId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Exercicio.Add(exercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoExercicioId = new SelectList(db.TipoExercicio, "TipoExercicioId", "TipoExercicioDesc", exercicio.TipoExercicioId);
            return View(exercicio);
        }

        // GET: Exercicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicio.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoExercicioId = new SelectList(db.TipoExercicio, "TipoExercicioId", "TipoExercicioDesc", exercicio.TipoExercicioId);
            return View(exercicio);
        }

        // POST: Exercicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExercicioId,ExercicioDesc,TipoExercicioId")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoExercicioId = new SelectList(db.TipoExercicio, "TipoExercicioId", "TipoExercicioDesc", exercicio.TipoExercicioId);
            return View(exercicio);
        }

        // GET: Exercicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicio.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // POST: Exercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercicio exercicio = db.Exercicio.Find(id);
            db.Exercicio.Remove(exercicio);
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
