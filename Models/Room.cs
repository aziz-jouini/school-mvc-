using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int roomID { get; set; }
        public string roomName { get; set; }
        public int roomSize { get; set; }
        public bool isAvaible { get; set; }
        public string location { get; set; }
    }
}