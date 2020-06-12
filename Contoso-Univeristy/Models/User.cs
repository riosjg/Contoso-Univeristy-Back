using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.Models
{
    public class User
    {
        private int id;
        private string mail;
        private string password;
        private string role;
        private int studentId;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public int StudentId { get => studentId; set => studentId = value; }
    }
}