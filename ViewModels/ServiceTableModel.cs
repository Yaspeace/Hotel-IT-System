using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_kursach_1.Models;

namespace IT_kursach_1
{
    public class ServiceTableModel
    {
        public List<Service> Services { get; set; }
        public List<Employee> Staff { get; set; }
        public string GetResponsible(Service s)
        {
            return Staff.Where(st => st.tabel == s.responsible_officer_id).First().fio;
        }
    }
}
