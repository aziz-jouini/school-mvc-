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
        public ActionResult GetCourses()
        {
            List<Course> courseLst = new List<Course>();
            courseLst = (from obj in myDB.Courses
                         select obj).ToList();

            return View("courses");

        }
        public ActionResult GetCourse(int id)
        {
            Course obj = new Course();
            obj = (from xyz in myDB.Courses
                   where xyz.courseID == id
                   select xyz).FirstOrDefault();
            return View("courses");

        }
        public ActionResult InsertCourse()
        {
            Course obj = new Course();
            obj.courseName = "test";
            obj.isAvaible = true;

            myDB.Courses.Add(obj);
            myDB.SaveChanges();
            return View("courses");
        }
        public ActionResult DeleteCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.Courses
                 where course.courseID == id
                 select course).FirstOrDefault();

            myDB.Courses.Remove(obj);
            myDB.SaveChanges();
            return View("courses");
        }
        public ActionResult UpdateCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.Courses
                   where course.courseID == id
                   select course).FirstOrDefault();

            obj.courseName = "test2";
            obj.isAvaible = false;
            myDB.SaveChanges();
            return View("courses");
        }
       



    }
}