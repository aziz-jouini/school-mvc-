using ABC__university.Models;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        SchoolContext myDB = new SchoolContext();
        public ActionResult Index()
        {
            List<Formation> FormationLst = new List<Formation>();
            FormationLst = (from Formation in myDB.Formations
                       select Formation).ToList();
            return View(FormationLst);
        }

        [HttpGet]
        public ActionResult InsertFormation()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertFormation(Formation Formation)
        {
            myDB.Formations.Add(Formation);
            myDB.SaveChanges();

            return RedirectToAction("Index"); // Rediriger vers une autre action après avoir ajouté l'enseignant avec succès
        }
        public ActionResult DeleteFormation(int id)
        {
            Formation obj = new Formation();
            obj = (from Formation in myDB.Formations
                   where Formation.formationID == id
                   select Formation).FirstOrDefault();
            myDB.Formations.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UpdateFormation(int id)
        {
            Formation Formation = myDB.Formations.FirstOrDefault(t => t.formationID == id);
            if (Formation == null)
            {
                return HttpNotFound();
            }
            return View(Formation);
        }
        [HttpPost]
        public ActionResult SaveFormation(Formation Formation)
        {
            var existingFormation = myDB.Formations.FirstOrDefault(t => t.formationID == Formation.formationID);
            if (existingFormation != null)
            {
                existingFormation.formationName = Formation.formationName;
                existingFormation.time = Formation.time;
                myDB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}