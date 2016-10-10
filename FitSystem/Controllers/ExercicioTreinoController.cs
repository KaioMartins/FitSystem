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
    public class ExercicioTreinoController : Controller
    {
        private BDContext db = new BDContext();

        // GET: ExercicioTreino
        public ActionResult Index()
        {
            var exercicioTreino = db.ExercicioTreino.Include(e => e.Dia).Include(e => e.Exercicio);
            return View(exercicioTreino.ToList());
        }

        // GET: ExercicioTreino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercicioTreino exercicioTreino = db.ExercicioTreino.Find(id);
            if (exercicioTreino == null)
            {
                return HttpNotFound();
            }
            return View(exercicioTreino);
        }

        // GET: ExercicioTreino/Create
        public ActionResult Create()
        {
            ViewBag.DiaId = new SelectList(db.Dia, "DiaId", "DiaDesc");
            ViewBag.ExercicioId = new SelectList(db.Exercicio, "ExercicioId", "ExercicioDesc");
            return View();
        }

        // POST: ExercicioTreino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExercicioTreinoId,Repeticao,Serie,DiaId,ExercicioId")] ExercicioTreino exercicioTreino)
        {
            if (ModelState.IsValid)
            {
                db.ExercicioTreino.Add(exercicioTreino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiaId = new SelectList(db.Dia, "DiaId", "DiaDesc", exercicioTreino.DiaId);
            ViewBag.ExercicioId = new SelectList(db.Exercicio, "ExercicioId", "ExercicioDesc", exercicioTreino.ExercicioId);
            return View(exercicioTreino);
        }

        // GET: ExercicioTreino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercicioTreino exercicioTreino = db.ExercicioTreino.Find(id);
            if (exercicioTreino == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiaId = new SelectList(db.Dia, "DiaId", "DiaDesc", exercicioTreino.DiaId);
            ViewBag.ExercicioId = new SelectList(db.Exercicio, "ExercicioId", "ExercicioDesc", exercicioTreino.ExercicioId);
            return View(exercicioTreino);
        }

        // POST: ExercicioTreino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExercicioTreinoId,Repeticao,Serie,DiaId,ExercicioId")] ExercicioTreino exercicioTreino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercicioTreino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiaId = new SelectList(db.Dia, "DiaId", "DiaDesc", exercicioTreino.DiaId);
            ViewBag.ExercicioId = new SelectList(db.Exercicio, "ExercicioId", "ExercicioDesc", exercicioTreino.ExercicioId);
            return View(exercicioTreino);
        }

        // GET: ExercicioTreino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercicioTreino exercicioTreino = db.ExercicioTreino.Find(id);
            if (exercicioTreino == null)
            {
                return HttpNotFound();
            }
            return View(exercicioTreino);
        }

        // POST: ExercicioTreino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExercicioTreino exercicioTreino = db.ExercicioTreino.Find(id);
            db.ExercicioTreino.Remove(exercicioTreino);
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
