using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentService.Controllers
{
    public class StdlinkproController : Controller
    {
        // GET: Stdlinkpro
        private StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
        {

            var courses = db.Links.ToList();
            return View(courses.ToList());
        }
        public ActionResult Del(int id)
        {

            var courses = db.Links.Where(a => a.LinkID == id);
            return View(courses.ToList());
        }
    }
}