using ABC__university.Models;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
      
        SchoolContext myDB = new SchoolContext();
        public ActionResult Index()
        {
            List<Teacher> teacherLst = new List<Teacher>();
            teacherLst = (from teacher in myDB.teachers
                          select teacher).ToList();
            return View(teacherLst);
        }

        [HttpGet]
        public ActionResult InsertTeacher()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertTeacher(Teacher teacher)
        {
            myDB.teachers.Add(teacher);
            myDB.SaveChanges();

            return RedirectToAction("Index"); // Rediriger vers une autre action après avoir ajouté l'enseignant avec succès
        }
        public ActionResult DeleteTeacher(int id)
        {
            Teacher obj = new Teacher();
            obj = (from teacher in myDB.teachers
                   where teacher.teacherID == id
                   select teacher).FirstOrDefault();
            myDB.teachers.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UpdateTeacher(int id)
        {
            Teacher teacher = myDB.teachers.FirstOrDefault(t => t.teacherID == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            var existingTeacher = myDB.teachers.FirstOrDefault(t => t.teacherID == teacher.teacherID);
            if (existingTeacher != null)
            {
                existingTeacher.teacherName = teacher.teacherName;
                existingTeacher.teacherNo = teacher.teacherNo;
                myDB.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}