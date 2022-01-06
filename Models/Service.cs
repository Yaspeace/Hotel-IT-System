using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Service
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public decimal? price { get; set; }
        public int enabled_category { get; set; }
        public int type_id { get; set; }
        public int responsible_officer_id { get; set; }

        public Service(int id, string name, decimal? price, int enabled_category, int type_id, int responsible_officer_id)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.enabled_category = enabled_category;
            this.type_id = type_id;
            this.responsible_officer_id = responsible_officer_id;
        }
        public Service() { }
    }
}
