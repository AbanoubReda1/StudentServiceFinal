using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentService.Controllers
{
    public class StdTaskController : Controller
    {
        // GET: StdTask
        StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
        {
            List<Department> Departmentlist = db.Departments.ToList();
            
            ViewBag.Departmentlist = new SelectList(Departmentlist, "DepartmentCode", "DepartmentName");

            var tasks = db.Tasks.Where(a => a.CourseCode == a.DepartmentCode);

            return View(tasks);
        }

        [HttpPost]
        public ActionResult Index(string CourseCode ,string Type)
        {
            List<Department> Departmentlist = db.Departments.ToList();
            ViewBag.Departmentlist = new SelectList(Departmentlist, "DepartmentCode", "DepartmentName");
            
            var courses = db.Tasks.Where(a => a.CourseCode == CourseCode).Where(b=> b.Type == Type).ToList();
           

            return View(courses);
            
        }
        public JsonResult GetTask(string DepartmentCode)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Course> courselist = db.Courses.Where(x => x.DepartmentCode == DepartmentCode).ToList();

            return Json(courselist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetType(string CourseCode)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Models.Task> types = db.Tasks.Where(x => x.CourseCode == CourseCode).ToList(); 


            return Json(types, JsonRequestBehavior.AllowGet);
        }
    }

}