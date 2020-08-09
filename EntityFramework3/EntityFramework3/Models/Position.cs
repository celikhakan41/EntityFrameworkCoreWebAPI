using EntityFramework3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework3
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionCode { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public byte Status { get; set; }


        public User User { get; set; }
    }
}
