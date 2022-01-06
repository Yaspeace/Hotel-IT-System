using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Subcategory
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int capasity { get; set; }
        public int number_of_rooms { get; set; }
        public int category { get; set; }
        public decimal price { get; set; }
        public Subcategory() { }

        public Subcategory(int id, string name, int capasity, int number_of_rooms, int category, decimal price)
        {
            this.id = id;
            this.name = name;
            this.capasity = capasity;
            this.number_of_rooms = number_of_rooms;
            this.category = category;
            this.price = price;
        }
    }
}
