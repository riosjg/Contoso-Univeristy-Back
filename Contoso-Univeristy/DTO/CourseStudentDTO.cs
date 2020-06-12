using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.DTO
{
    public class CourseStudentDTO
    {
        private int courseId;
        private int studentId;
        private string courseTitle;
        private string studentFullName;

        public int CourseId { get => courseId; set => courseId = value; }
        public int StudentId { get => studentId; set => studentId = value; }
        public string CourseTitle { get => courseTitle; set => courseTitle = value; }
        public string StudentFullName { get => studentFullName; set => studentFullName = value; }
    }
}