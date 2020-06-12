using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.Models
{
    public class Constants
    {
        const string roleStudent = "Student";
        const string roleAdmin = "Admin";
        const string roleInstructor = "Instructor";

        public static string RoleStudent => roleStudent;

        public static string RoleAdmin => roleAdmin;

        public static string RoleInstructor => roleInstructor;
    }
}