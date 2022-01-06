using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Country
    {
        [Key]
        public int country_code { get; set; }
        public string country_wordcode { get; set; }
        public string country_name { get; set; }
        public Country()
        { }

        public Country(int code, string wordcode, string name)
        {
            this.country_code = code;
            this.country_wordcode = wordcode;
            this.country_name = name;
        }
    }
}
