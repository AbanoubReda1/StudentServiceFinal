using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentService.Models;

namespace StudentService.Controllers
{
    public class TranscriptsController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: Transcripts
        public ActionResult Index()
        {
            return View(db.Transcripts.ToList());
        }

        // GET: Transcripts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcript transcript = db.Transcripts.Find(id);
            if (transcript == null)
            {
                return HttpNotFound();
            }
            return View(transcript);
        }

        // GET: Transcripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transcripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,SectionNumber,Semester,Year")] Transcript transcript)
        {
            if (ModelState.IsValid)
            {
                db.Transcripts.Add(transcript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transcript);
        }

        // GET: Transcripts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcript transcript = db.Transcripts.Find(id);
            if (transcript == null)
            {
                return HttpNotFound();
            }
            return View(transcript);
        }

        // POST: Transcripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,SectionNumber,Semester,Year")] Transcript transcript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transcript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transcript);
        }

        // GET: Transcripts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcript transcript = db.Transcripts.Find(id);
            if (transcript == null)
            {
                return HttpNotFound();
            }
            return View(transcript);
        }

        // POST: Transcripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Transcript transcript = db.Transcripts.Find(id);
            db.Transcripts.Remove(transcript);
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
