using StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentService.Controllers
{
    public class ProjectStdController : Controller
    {
        // GET: ProjectStd
        private StudentServiceEntities db = new StudentServiceEntities();
        public ActionResult Index()
        {
           
            ViewBag.projectlist = new SelectList(db.Projects, "ProjectID", "ProjectName");
            var projects = db.Projects.Where(a=>a.ProjectName==a.Professor);
            return View(projects.ToList());
        }
        [HttpPost]
        public ActionResult Index(int? projectlist)
        {
           
            ViewBag.projectlist = new SelectList(db.Projects, "ProjectID", "ProjectName");

            var project = db.Projects.Where(a => a.ProjectID == projectlist).ToList();

            return View(project.ToList());
        }


        public ActionResult All()
        {

            
            var projects = db.Projects.ToList();
            return View(projects.ToList());
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
