using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Security;

namespace ABC__university.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolConnectionString")
        {

        }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}