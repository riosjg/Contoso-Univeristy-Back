using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.Models
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int CourseCapacity { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }
        public int InstructorId { get; set; }
        public string InstructorFullName{ get; set; }
    }
}