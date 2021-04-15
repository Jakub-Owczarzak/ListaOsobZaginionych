using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OsobyZaginioneFinal.Models;

namespace OsobyZaginioneFinal.Controllers
{
    public class PageController : Controller
    {
        private listazaginonychEntities db = new listazaginonychEntities();

        // GET: Page
        public ActionResult Index()
        {
            var osobas = db.osobas.Include(o => o.city).Include(o => o.status);
            return View(osobas.ToList());
        }

        // GET: Page/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba osoba = db.osobas.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // GET: Page/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.cities, "Id", "city1");
            ViewBag.status_id = new SelectList(db.status, "Id", "status1");
            return View();
        }

        // POST: Page/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstname,lastname,alias,city_id,status_id,tel")] osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.osobas.Add(osoba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.cities, "Id", "city1", osoba.city_id);
            ViewBag.status_id = new SelectList(db.status, "Id", "status1", osoba.status_id);
            return View(osoba);
        }

        // GET: Page/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba osoba = db.osobas.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.cities, "Id", "city1", osoba.city_id);
            ViewBag.status_id = new SelectList(db.status, "Id", "status1", osoba.status_id);
            return View(osoba);
        }

        // POST: Page/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstname,lastname,alias,city_id,status_id,tel")] osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.cities, "Id", "city1", osoba.city_id);
            ViewBag.status_id = new SelectList(db.status, "Id", "status1", osoba.status_id);
            return View(osoba);
        }

        // GET: Page/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            osoba osoba = db.osobas.Find(id);
            if (osoba == null)
            {
                return HttpNotFound();
            }
            return View(osoba);
        }

        // POST: Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osoba osoba = db.osobas.Find(id);
            db.osobas.Remove(osoba);
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
