using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentService.Controllers
{
    public class StudeCourseController : Controller
    {
        // GET: StudeCourse
        StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
            {
                List<Department> Departmentlist = db.Departments.ToList();
                ViewBag.Departmentlist = new SelectList(Departmentlist, "DepartmentCode", "DepartmentName");

            var courses = db.Courses.Where(a => a.CourseCode == a.DepartmentCode);

                return View(courses);
            }

        [HttpPost]
        public ActionResult Index(string CourseCode)
        {
            List<Department> Departmentlist = db.Departments.ToList();
            ViewBag.Departmentlist = new SelectList(Departmentlist, "DepartmentCode", "DepartmentName");
         
            var courses = db.Courses.Where(a => a.CourseTitle == CourseCode).ToList();

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