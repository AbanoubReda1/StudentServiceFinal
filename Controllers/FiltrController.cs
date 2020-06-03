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



        public ActionResult Task(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task course = db.Tasks.FirstOrDefault(a => a.CourseCode == id);

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
            Task course = db.Tasks.FirstOrDefault(a => a.CourseCode == id);

            var task = db.Tasks.Where(a => a.CourseCode == id).Where(a=>a.Type==id2).ToList();
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        
         }
    }
}