using Contoso_Univeristy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.DAL
{
    public class ContosoDbContext : DbContext
    {
        public ContosoDbContext() : base("ContosoDb")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}