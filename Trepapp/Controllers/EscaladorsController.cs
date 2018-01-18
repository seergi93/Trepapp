using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    public class EscaladorsController : Controller
    {
        private EscaladorDBContext db = new EscaladorDBContext();

        // GET: Escaladors
        public ActionResult Index()
        {
            return View(db.Escaladors.ToList());
        }

        // GET: Escaladors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalador escalador = db.Escaladors.Find(id);
            if (escalador == null)
            {
                return HttpNotFound();
            }
            return View(escalador);
        }

        // GET: Escaladors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escaladors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Llinatge,Edat,CorreuElectronic")] Escalador escalador)
        {
            if (ModelState.IsValid)
            {
                db.Escaladors.Add(escalador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escalador);
        }

        // GET: Escaladors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalador escalador = db.Escaladors.Find(id);
            if (escalador == null)
            {
                return HttpNotFound();
            }
            return View(escalador);
        }

        // POST: Escaladors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Llinatge,Edat,CorreuElectronic")] Escalador escalador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escalador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escalador);
        }

        // GET: Escaladors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escalador escalador = db.Escaladors.Find(id);
            if (escalador == null)
            {
                return HttpNotFound();
            }
            return View(escalador);
        }

        // POST: Escaladors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Escalador escalador = db.Escaladors.Find(id);
            db.Escaladors.Remove(escalador);
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
