using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class OrderedService
    {
        [Key]
        public int id { get; set; }
        public int booking_id { get; set; }
        public int service_id { get; set; }

        public OrderedService(int id, int booking_id, int service_id)
        {
            this.id = id;
            this.booking_id = booking_id;
            this.service_id = service_id;
        }
    }
}
