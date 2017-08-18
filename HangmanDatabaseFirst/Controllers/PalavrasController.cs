using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HangmanDatabaseFirst;

namespace HangmanDatabaseFirst.Controllers
{
    public class PalavrasController : Controller
    {
        private hangmanDatabaseFirstDBEntities db = new hangmanDatabaseFirstDBEntities();

        // GET: Palavras
        public ActionResult Index()
        {
            return View(
                
                db.Palavras.ToList()



            );
        }

        // GET: Palavras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palavra palavra = db.Palavras.Find(id);
            if (palavra == null)
            {
                return HttpNotFound();
            }
            return View(palavra);
        }

        // GET: Palavras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Palavras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "palavra1,id_dificuldade")] Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                db.Palavras.Add(palavra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(palavra);
        }

        // GET: Palavras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palavra palavra = db.Palavras.Find(id);
            if (palavra == null)
            {
                return HttpNotFound();
            }
            return View(palavra);
        }

        // POST: Palavras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "palavra1,id_dificuldade")] Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palavra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(palavra);
        }

        // GET: Palavras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palavra palavra = db.Palavras.Find(id);
            if (palavra == null)
            {
                return HttpNotFound();
            }
            return View(palavra);
        }

        // POST: Palavras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Palavra palavra = db.Palavras.Find(id);
            db.Palavras.Remove(palavra);
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
