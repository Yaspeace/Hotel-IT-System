using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Room
    {
        [Key]
        public int room_number { get; set; }
        public int subcategory { get; set; }
        public string status { get; set; }
        public Room() { }

        public Room(int room_number, int subcategory, string status)
        {
            this.room_number = room_number;
            this.subcategory = subcategory;
            this.status = status;
        }
    }
}
