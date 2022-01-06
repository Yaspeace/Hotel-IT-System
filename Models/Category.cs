using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
        public Category() { }
        public Category(int category_id, string category_name)
        {
            this.category_id = category_id;
            this.category_name = category_name;
        }
    }
}
