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
    public class StdMaterialsController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: StdMaterials
        public ActionResult Index()
        {
            List<Department> Departmentlist = db.Departments.ToList();
            ViewBag.Departmentlist = new SelectList(Departmentlist, "DepartmentCode", "DepartmentName");
            var materials = db.Materials.Include(m => m.Section).Where(a=>a.CourseCode==a.DepartmentCode);
            return View(materials.ToList());
        }
        [HttpPost]
        public ActionResult Index(string CourseCode)
        {
            List<Department> Departmentlist = db.Departments.ToList();
            ViewBag.Departmentlist = new SelectList(Departmentlist, "DepartmentCode", "DepartmentName");

            var courses = db.Materials.Where(a => a.CourseCode == CourseCode).ToList();

            return View(courses);
        }
        public JsonResult GetCourse(string DepartmentCode)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Course> courselist = db.Courses.Where(x => x.DepartmentCode == DepartmentCode).ToList();

            return Json(courselist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DownloadFile(string filePath)
        {
            string fullName = Server.MapPath("" + filePath);

            byte[] fileBytes = GetFile(fullName);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
    }
}
