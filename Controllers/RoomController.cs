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
        // GET: Room
        public ActionResult Index()
        {
            List<Room> roomLst = new List<Room>();
            roomLst = (from room in myDB.rooms
                       select room).ToList();
            return View();
        }
        public ActionResult GetDetails(int roomId)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == roomId
                   select room).FirstOrDefault();
            return View("RoomDetails");

        }
        public ActionResult DeleteRoom(int id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == id
                   select room).FirstOrDefault();
            myDB.rooms.Remove(obj);
            myDB.SaveChanges();
            return View("Index");

        }
        public ActionResult UpdateRoom(int roomId )
        {
           Room obj = new Room();
            obj = (from room in myDB.rooms
                   where room.roomID == roomId
                   select room).FirstOrDefault();

            obj.roomName = "new room Name";

            myDB.SaveChanges();
            return View("index");
        }
        public ActionResult InsertRoom()
        {
            Room obj = new Room();
            obj.isAvaible = true;
            obj.location = "tunis";
            obj.roomSize = 10;

            myDB.rooms.Add(obj);
            myDB.SaveChanges();
            return View("index");
        }
    }
}