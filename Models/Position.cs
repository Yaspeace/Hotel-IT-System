using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Position
    {
        [Key]
        public int code { get; set; }
        public string position_name { get; set; }

        public Position(int code, string position_name)
        {
            this.code = code;
            this.position_name = position_name;
        }
    }
}
