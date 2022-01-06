using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Employee
    {
        [Key]
        public int tabel { get; set; }
        public int position { get; set; }
        public string fio { get; set; }
        public DateTime employment_date { get; set; }
        public DateTime? fire_date { get; set; }
        public string status { get; set; }

        public Employee(int tabel, int position, string fio, DateTime employment_date, DateTime? fire_date, string status)
        {
            this.tabel = tabel;
            this.position = position;
            this.fio = fio;
            this.employment_date = employment_date;
            this.fire_date = fire_date;
            this.status = status;
        }
    }
}
