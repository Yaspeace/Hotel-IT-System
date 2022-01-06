using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_kursach_1.Models
{
    public class BookingInfo
    {
        public int id { get; set; }
        public int cl_id { get; set; }
        public int room { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
        public DateTime booking_date { get; set; }
        public string status { get; set; }
        public int adults_num { get; set; }
        public int childs_num { get; set; }
        public decimal summ { get; set; }
        public string scat_name { get; set; }
        public string cat_name { get; set; }
    }
}
