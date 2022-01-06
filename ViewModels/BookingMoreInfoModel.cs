using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_kursach_1.Models;

namespace IT_kursach_1
{
    public class BookingMoreInfoModel
    {
        public List<Guest> Guests { get; set; }
        public List<Service> Services { get; set; }
        public List<Country> GuestCitizens { get; set; }
        public string GetGuestFIO(Guest g)
        {
            return g.surname + " " + g.name + " " + g.patronymic;
        }
        public string GetCitizen(Guest g)
        {
            return GuestCitizens.Where(c => c.country_code == g.citizenship).First().country_name;
        }
    }
}
