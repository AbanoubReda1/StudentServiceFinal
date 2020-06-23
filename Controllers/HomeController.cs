using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentService.Controllers
{
    public class HomeController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult pop()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    
    }
}