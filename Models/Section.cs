using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabbTsb.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string Department { get; set; }

        public List<Employee> Employees { get; } = new List<Employee>();
    }
}
