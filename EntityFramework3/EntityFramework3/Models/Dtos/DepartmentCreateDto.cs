using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework3.Models.Dtos
{
    public class DepartmentCreateDto
    {
		public int DepartmentId { get; set; }
		public string DepartmentCode { get; set; }
		public string Name { get; set; }
		public int ManagerDepartmentId { get; set; }
		public int ManagerUserId { get; set; }
		public byte Status { get; set; }
	}
}
