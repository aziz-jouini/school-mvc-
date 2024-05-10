using ABC__university.Models;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class RoomController : Controller

    {
        SchoolContext myDB = new SchoolContext();
        public ActionResult Index()
        {
            List<Room> RoomLst = new List<Room>();
            RoomLst = (from Room in myDB.rooms
                          select Room).ToList();
            return View(RoomLst);
        }

        [HttpGet]
        public ActionResult InsertRoom()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertRoom(Room Room)
        {
            myDB.rooms.Add(Room);
            myDB.SaveChanges();

            return RedirectToAction("Index"); // Rediriger vers une autre action après avoir ajouté l'enseignant avec succès
        }
        public ActionResult DeleteRoom(int id)
        {
            Room obj = new Room();
            obj = (from Room in myDB.rooms
                   where Room.roomID == id
                   select Room).FirstOrDefault();
            myDB.rooms.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UpdateRoom(int id)
        {
            Room Room = myDB.rooms.FirstOrDefault(t => t.roomID == id);
            if (Room == null)
            {
                return HttpNotFound();
            }
            return View(Room);
        }
        [HttpPost]
        public ActionResult SaveRoom(Room Room)
        {
            var existingRoom = myDB.rooms.FirstOrDefault(t => t.roomID == Room.roomID);
            if (existingRoom != null)
            {
                existingRoom.roomName = Room.roomName;
                existingRoom.roomSize = Room.roomSize;
                myDB.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}