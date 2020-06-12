using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso_Univeristy.DTO
{
    public class UserDTO
    {
        private int studentId;
        private string role;

        public int StudentId { get => studentId; set => studentId = value; }
        public string Role { get => role; set => role = value; }
    }
}