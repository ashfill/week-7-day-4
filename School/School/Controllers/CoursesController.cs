using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class CoursesController : Controller
    {
        private SchoolEntities db = new SchoolEntities();
        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }
        //GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}