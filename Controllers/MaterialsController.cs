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
    public class MaterialsController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: Materials
        public ActionResult Index()
        {
            var materials = db.Materials.Include(m => m.Section);
            return View(materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.FirstOrDefault(a => a.MaterialNumber==id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentCode = new SelectList(db.Sections, "DepartmentCode", "DepartmentCode");
            ViewBag.CourseCode = new SelectList(db.Sections, "CourseCode", "CourseCode");
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber");
            ViewBag.Semester = new SelectList(db.Sections, "Semester", "Semester");
            ViewBag.Year = new SelectList(db.Sections, "Year", "Year");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Material material)
        {
                     ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode", material.DepartmentCode);
            ViewBag.CourseCode = new SelectList(db.Sections, "CourseCode", "CourseCode", material.CourseCode);
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber", material.SectionNumber);
            ViewBag.Semester = new SelectList(db.Sections, "Semester", "Semester", material.Semester);
            ViewBag.Year = new SelectList(db.Sections, "Year", "Year", material.Year);

            string fileName = Path.GetFileNameWithoutExtension(material.file.FileName);
            string extension = Path.GetExtension(material.file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            material.PDF = "~/uploads/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/uploads/"), fileName);
            material.file.SaveAs(fileName);
            using (StudentServiceEntities db = new StudentServiceEntities())
            {
                db.Materials.Add(material);

                db.SaveChanges();
         


            }

   
            ModelState.Clear();
            return View(material);
        }
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.FirstOrDefault(a => a.MaterialNumber == id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentCode = new SelectList(db.Departments, "DepartmentCode", "DepartmentCode", material.DepartmentCode);
            ViewBag.CourseCode = new SelectList(db.Sections, "CourseCode", "CourseCode", material.CourseCode);
            ViewBag.SectionNumber = new SelectList(db.Sections, "SectionNumber", "SectionNumber", material.SectionNumber);
            ViewBag.Semester = new SelectList(db.Sections, "Semester", "Semester", material.Semester);
            ViewBag.Year = new SelectList(db.Sections, "Year", "Year", material.Year);
            return View(material);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialNumber,DepartmentCode,CourseCode,SectionNumber,Semester,Year,LectureNumber,LectureName,PDF")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentCode = new SelectList(db.Sections, "DepartmentCode", "DepartmentCode", material.DepartmentCode);
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.FirstOrDefault(a => a.MaterialNumber == id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materials.FirstOrDefault(a => a.MaterialNumber == id);
            db.Materials.Remove(material);
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
