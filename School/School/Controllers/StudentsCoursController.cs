using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School;

namespace School.Controllers
{
    public class StudentsCoursController : Controller
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: StudentsCours
        public ActionResult Index()
        {
            var studentsCourses = db.StudentsCourses.Include(s => s.Cours).Include(s => s.Student);
            return View(studentsCourses.ToList());
        }

        // GET: StudentsCours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsCours studentsCours = db.StudentsCourses.Find(id);
            if (studentsCours == null)
            {
                return HttpNotFound();
            }
            return View(studentsCours);
        }

        // GET: StudentsCours/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: StudentsCours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,CourseID,Geez")] StudentsCours studentsCours)
        {
            if (ModelState.IsValid)
            {
                db.StudentsCourses.Add(studentsCours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentsCours.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", studentsCours.StudentID);
            return View(studentsCours);
        }

        // GET: StudentsCours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsCours studentsCours = db.StudentsCourses.Find(id);
            if (studentsCours == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentsCours.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", studentsCours.StudentID);
            return View(studentsCours);
        }

        // POST: StudentsCours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,CourseID,Geez")] StudentsCours studentsCours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsCours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentsCours.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", studentsCours.StudentID);
            return View(studentsCours);
        }

        // GET: StudentsCours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsCours studentsCours = db.StudentsCourses.Find(id);
            if (studentsCours == null)
            {
                return HttpNotFound();
            }
            return View(studentsCours);
        }

        // POST: StudentsCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsCours studentsCours = db.StudentsCourses.Find(id);
            db.StudentsCourses.Remove(studentsCours);
            db.SaveChanges();
            return RedirectToAction("Index");
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
