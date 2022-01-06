using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_kursach_1.Models;

namespace IT_kursach_1
{
    public class StaffModel
    {
        public List<Employee> Staff { get; set; }
        public List<Position> Positions { get; set; }
        public string GetPosition(Employee e)
        {
            return Positions.Where(p => p.code == e.position).First().position_name;
        }
    }
}
