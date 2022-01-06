using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Administrator
    {
        [Key]
        public int admin_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronym { get; set; }
        public Administrator() { }
        public Administrator(int id, string name, string surname, string patronym, string login, string password)
        {
            admin_id = id;
            this.name = name;
            this.surname = surname;
            this.patronym = patronym;
            this.login = login;
            this.password = password;
        }
    }
}
