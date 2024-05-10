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
            studentLst = (from Student in myDB.students
                          select Student).ToList();
            return View(studentLst);
        }

        [HttpGet]
        public ActionResult InsertStudent()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertStudent(Student Student)
        {
            myDB.students.Add(Student);
            myDB.SaveChanges();

            return RedirectToAction("Index"); // Rediriger vers une autre action après avoir ajouté l'enseignant avec succès
        }
        public ActionResult DeleteStudent(int id)
        {
            Student obj = new Student();
            obj = (from Student in myDB.students
                   where Student.studentID == id
                   select Student).FirstOrDefault();
            myDB.students.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UpdateStudent(int id)
        {
            Student Student = myDB.students.FirstOrDefault(t => t.studentID == id);
            if (Student == null)
            {
                return HttpNotFound();
            }
            return View(Student);
        }
        [HttpPost]
        public ActionResult SaveStudent(Student Student)
        {
            var existingStudent = myDB.students.FirstOrDefault(t => t.studentID == Student.studentID);
            if (existingStudent != null)
            {
                existingStudent.studentName = Student.studentName;
                existingStudent.studentNo = Student.studentNo;
                myDB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}