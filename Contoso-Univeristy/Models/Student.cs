using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
        }
        private int id;
        private string name;
        private string lastName;
        private string dni;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Dni { get => dni; set => dni = value; }
        public ICollection<Course> Courses { get; set; }
    }
}