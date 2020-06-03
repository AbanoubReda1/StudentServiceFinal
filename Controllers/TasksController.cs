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
    public class TasksController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.Section).Include(t => t.Type1);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode");
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "CourseCode");
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber");
            ViewBag.Semester = new SelectList(db.Sections, "Semester", "Semester");
            ViewBag.Year = new SelectList(db.Sections, "Year", "Year");
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeID");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskNumber,DepartmentCode,CourseCode,SectionNumber,Semester,Year,TaskHeader,TaskDetails,Type")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode", task.DepartmentCode);
            ViewBag.CourseCode = new SelectList(db.Sections, "CourseCode", "CourseCode", task.CourseCode);
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber", task.SectionNumber);
            ViewBag.Semester = new SelectList(db.Sections, "Semester", "Semester", task.Semester);
            ViewBag.Year = new SelectList(db.Sections, "Year", "Year", task.Year);
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeID", task.Type);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode", task.DepartmentCode);
            ViewBag.CourseCode = new SelectList(db.Sections, "CourseCode", "CourseCode", task.CourseCode);
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber", task.SectionNumber);
            ViewBag.Semester = new SelectList(db.Sections, "Semester", "Semester", task.Semester);
            ViewBag.Year = new SelectList(db.Sections, "Year", "Year", task.Year);
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeID", task.Type);
            return View(task);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskNumber,DepartmentCode,CourseCode,SectionNumber,Semester,Year,TaskHeader,TaskDetails,Type")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentCode = new SelectList(db.Sections, "DepartmentCode", "DepartmentCode", task.DepartmentCode);
            ViewBag.Type = new SelectList(db.Types, "TypeID", "TypeName", task.Type);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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
