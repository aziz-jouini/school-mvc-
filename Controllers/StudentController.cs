using ABC__university.Models;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        SchoolContext myDB = new SchoolContext();
        public ActionResult Index()
        {
            List<Student> studentLst = new List<Student>();
            studentLst = (from student in myDB.students
                          select student).ToList();
            return View();
        }
    }
}