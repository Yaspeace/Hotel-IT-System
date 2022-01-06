using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }
        public string passport_number { get; set; }
        public DateTime birthday { get; set; }
        public int citizenship { get; set; }
        public string client_surname { get; set; }
        public string client_name { get; set; }
        public string client_patronym { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Client() 
        {
        }
        public Client(int client_id, string passport, DateTime birthday, int citizen, string name, string surname, string patr, string login, string passw, string phone, string email)
        {
            this.client_id = client_id;
            this.passport_number = passport;
            this.birthday = birthday;
            this.citizenship = citizen;
            this.client_name = name;
            this.client_surname = surname;
            this.client_patronym = patr;
            this.login = login;
            this.password = password;
            this.phone = phone;
            this.email = email;
        }
    }
}
