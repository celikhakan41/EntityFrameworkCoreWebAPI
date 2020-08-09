using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework3.Models.Dtos
{
    public class UserCreateDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DisplayName { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte Gender { get; set; }
        public DateTime? WorkStart { get; set; }
        public DateTime? WorkEnd { get; set; }
        public byte Status { get; set; }
        public byte Type { get; set; }
        public int DepartmentId { get; set; }
        public int TitleId { get; set; }
        public int ManagerUserId { get; set; }
        public string Language { get; set; }
        public int TimeZone { get; set; }
        public string Culture { get; set; }
        public string Picture { get; set; }
    }
}
