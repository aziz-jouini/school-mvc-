using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Formation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int formationID { get; set; }
        public string formationName { get; set; }
        public DateTime time { get; set; }
        public bool isAvaible { get; set; }
        // Clé étrangère
        public int CourseID { get; set; }
        // Propriété de navigation vers Course
        public Course Course { get; set; }
    }
}