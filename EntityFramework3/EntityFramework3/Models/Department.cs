using EntityFramework3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework3
{
    public class Department
    {
		public int DepartmentId { get; set; }
		public string DepartmentCode { get; set; }
		public string Name { get; set; }
		public int ManagerDepartmentId { get; set; }
		public int ManagerUserId { get; set; }
		public byte Status { get; set; }

		public User User { get; set; }
	}
}
