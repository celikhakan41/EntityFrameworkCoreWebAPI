using EntityFramework3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework3
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public byte IsIntegrationData { get; set; }

        public User User { get; set; }
    }
}
