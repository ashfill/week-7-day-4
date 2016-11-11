using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class StudentsCoursesController : Controller
    {
        // GET: StudentsCourses
        public ActionResult Index()
        {
            return View();
        }
    }
}