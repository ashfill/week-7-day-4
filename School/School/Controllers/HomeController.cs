using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        SchoolEntities db = new SchoolEntities();
        // GET: Home
        public ActionResult Index()
        {
            var Info = from detail in db.Students
                       join stun in db.StudentsCourses on detail.StudentID equals stun.StudentID
                       join course in db.Courses on stun.CourseID equals course.CourseID
                       select new
                       {
                           AA = detail,
                           BB = course
                       };

            return View(Info);
        }
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "StudentName");
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="StudentID,CourseID")]StudentsCours Info)
        {
            if(ModelState.IsValid)
            {
                db.StudentsCourses.Add(Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "StudentName");
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName");
            return View(Info);
        }
    }
}