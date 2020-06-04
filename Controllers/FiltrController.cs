using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace StudentService.Views
{
    public class FiltrController : Controller
    {
        // GET: Filtr
        StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
        {


            ViewBag.DepartmentCode = db.Departments.ToList();

            ViewBag.course = db.Courses.ToList();
            ViewBag.Types = db.Types.ToList();
            ViewBag.task = db.Tasks.ToList();
            
            return View();
           
          

        }


        public ActionResult Courses(string id)
        {

            var course = db.Courses.Where(a=>a.DepartmentCode == id);
            return View(course.ToList());
            



        }
        public ActionResult Filter(string id)
        {
            
            return View();

          




        }

        public ActionResult Task(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var course = db.Tasks.Where(a => a.CourseCode == id);

            var task = db.Tasks.Where(a => a.CourseCode == id).ToList();
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);

        }
   
    public ActionResult pol(string id,string id2)
        {  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           

            var task = db.Tasks.Where(a => a.CourseCode == id).Where(a=>a.Type==id2).ToList();
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        
         }
    }
}