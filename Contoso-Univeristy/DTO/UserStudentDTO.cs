using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.DTO
{
    public class UserStudentDTO
    {
        private string dni;
        private string mail;
        private string password;

        public string Dni { get => dni; set => dni = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
    }
}