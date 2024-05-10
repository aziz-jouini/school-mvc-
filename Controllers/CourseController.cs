using ABC__university.Models;
using School.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace school.Controllers
{
    public class CourseController : Controller
    {

        SchoolContext myDB = new SchoolContext();
        public ActionResult Index()
        {
            List<Course> CourseLst = new List<Course>();
            CourseLst = (from Course in myDB.Courses
                          select Course).ToList();
            return View(CourseLst);
        }

        [HttpGet]
        public ActionResult InsertCourse()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertCourse(Course Course)
        {
            myDB.Courses.Add(Course);
            myDB.SaveChanges();

            return RedirectToAction("Index"); 
        }
        public ActionResult DeleteCourse(int id)
        {
            Course obj = new Course();
            obj = (from Course in myDB.Courses
                   where Course.courseID == id
                   select Course).FirstOrDefault();
            myDB.Courses.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UpdateCourse(int id)
        {
            Course Course = myDB.Courses.FirstOrDefault(t => t.courseID == id);
            if (Course == null)
            {
                return HttpNotFound();
            }
            return View(Course);
        }
        [HttpPost]
        public ActionResult SaveCourse(Course Course)
        {
            var existingCourse = myDB.Courses.FirstOrDefault(t => t.courseID == Course.courseID);
            if (existingCourse != null)
            {
                existingCourse.courseName = Course.courseName;
                existingCourse.isAvaible = Course.isAvaible;
                myDB.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}