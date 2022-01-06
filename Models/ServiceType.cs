using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class ServiceType
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public ServiceType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
