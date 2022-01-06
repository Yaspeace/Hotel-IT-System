using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_kursach_1.Models
{
    public class UserBookingsModel
    {
        public List<Service> services { get; set; }
        public List<OrderedService> oservices { get; set; }
    }
}
