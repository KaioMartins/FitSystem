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
    public class TreinoController : Controller
    {
        private BDContext db = new BDContext();

        // GET: Treino
        public ActionResult Index()
        {
            var treino = db.Treino.Include(t => t.Dia);
            return View(treino.ToList());
        }

        // GET: Treino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treino.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // GET: Treino/Create
        public ActionResult Create()
        {
            ViewBag.ExercicioTreinoId = new SelectList(db.ExercicioTreino, "ExercicioTreinoId", "ExercicioTreinoId");
            return View();
        }

        // POST: Treino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreinoId,ExercicioTreinoId")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Treino.Add(treino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExercicioTreinoId = new SelectList(db.ExercicioTreino, "ExercicioTreinoId", "ExercicioTreinoId", treino.ExercicioTreinoId);
            return View(treino);
        }

        // GET: Treino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treino.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExercicioTreinoId = new SelectList(db.ExercicioTreino, "ExercicioTreinoId", "ExercicioTreinoId", treino.ExercicioTreinoId);
            return View(treino);
        }

        // POST: Treino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreinoId,ExercicioTreinoId")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExercicioTreinoId = new SelectList(db.ExercicioTreino, "ExercicioTreinoId", "ExercicioTreinoId", treino.ExercicioTreinoId);
            return View(treino);
        }

        // GET: Treino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treino.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // POST: Treino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treino treino = db.Treino.Find(id);
            db.Treino.Remove(treino);
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
