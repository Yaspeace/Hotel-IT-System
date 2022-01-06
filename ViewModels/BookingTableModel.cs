using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_kursach_1.Models
{
    public class BookingTableModel
    {
        public List<BookingInfo> BookingsInfo { get; set; }
        public List<Client> Clients { get; set; }
        public string GetClientFIO(int cl_id)
        {
            string cl_name = Clients.Where(c => c.client_id == cl_id).First().client_name;
            string cl_surname = Clients.Where(c => c.client_id == cl_id).First().client_surname;
            string cl_patr = Clients.Where(c => c.client_id == cl_id).First().client_patronym;
            return cl_surname + " " + cl_name + " " + cl_patr;
        }
    }
}
