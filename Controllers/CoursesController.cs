using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentService.Models;

namespace StudentService.Controllers
{
    public class CoursesController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: Courses

        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.FirstOrDefault(a => a.CourseCode == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Courses.Add(course);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
             
            string fileName = Path.GetFileNameWithoutExtension(course.file.FileName);
            string extension = Path.GetExtension(course.file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            course.Syllabus = "~/uploads/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/uploads/"), fileName);
            course.file.SaveAs(fileName);
            using(StudentServiceEntities db=new StudentServiceEntities())
            {
                db.Courses.Add(course);
                db.SaveChanges();
               

            }

            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentName", course.DepartmentCode);
            ModelState.Clear();

           
            return View(course);
            
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.FirstOrDefault(a => a.CourseCode == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentName", course.DepartmentCode);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentCode,CourseCode,CourseTitle,CrediteHour,Syllabus")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentName", course.DepartmentCode);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.FirstOrDefault(a => a.CourseCode == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Course course = db.Courses.FirstOrDefault(a => a.CourseCode == id);
            db.Courses.Remove(course);
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
