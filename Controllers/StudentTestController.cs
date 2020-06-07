using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentService.Models;
namespace StudentService.Controllers
{
    public class StudentTestController : Controller
    {
        // GET: StudentTest
        private StudentServiceEntities db = new StudentServiceEntities();

        public ActionResult Index(string id,string id2)
        {
            var test = db.Tests.Where(a => a.CourseCode == id).Where(a => a.Type == id2);
            return View(test.ToList());
        }
        public ActionResult Index1()
        {


            ViewBag.DepartmentCode = db.Departments.ToList();

            ViewBag.course = db.Courses.ToList();
            ViewBag.Types = db.Types.ToList();
            ViewBag.task = db.Tasks.ToList();

            return View();



        }


        public ActionResult Courses(string id)
        {

            var course = db.Courses.Where(a => a.DepartmentCode == id);
            return View(course.ToList());




        }
        public ActionResult Filter(string id)
        {
            var sec = db.Sections.Where(a => a.CourseCode == id);
            return View(sec.ToList());






        }

    }
}