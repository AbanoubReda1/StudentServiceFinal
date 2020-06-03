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
    [Authorize(Roles = "Admin")]
    public class SectionsController : Controller
    {
        private readonly StudentServiceEntities db = new StudentServiceEntities();

        // GET: Sections
        public ActionResult Index()
        {
            var sections = db.Sections.Include(s => s.Course).Include(s => s.Instructor);
            return View(sections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode");
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "CourseTitle ");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentCode,CourseCode,SectionNumber,Semester,Year,InstructorID")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentName ", section.DepartmentCode);
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "CourseTitle ", section.CourseCode);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName", section.InstructorID);
            return View(section);
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentCode = new SelectList(db.Courses, "DepartmentCode", "CourseTitle", section.DepartmentCode);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName", section.InstructorID);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentCode,CourseCode,SectionNumber,Semester,Year,InstructorID")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentCode = new SelectList(db.Courses, "DepartmentCode", "CourseTitle", section.DepartmentCode);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorName", section.InstructorID);
            return View(section);
        }

        // GET: Sections/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Section section = db.Sections.Find(id);
            db.Sections.Remove(section);
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
