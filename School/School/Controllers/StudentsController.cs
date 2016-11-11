using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Stidents
        public ActionResult Index()
        {
            return View();
        }
    }
}