using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentService.Models;

namespace StudentService.Controllers.Student
{
    public class StdLinksController : Controller
    {
        private StudentServiceEntities db = new StudentServiceEntities();

        // GET: StdLinks
        public ActionResult Index()
        {
            return View(db.Links.ToList());
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
