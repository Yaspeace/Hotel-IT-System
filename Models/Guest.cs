using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Guest
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public DateTime birthday { get; set; }
        public string passport { get; set; }
        public int citizenship { get; set; }
        public int booking_id { get; set; }
        public int room_id { get; set; }

        public Guest(int id, string name, string surname, string patronymic, DateTime birthday, string passport, int citizenship, int booking_id, int room_id)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.birthday = birthday;
            this.passport = passport;
            this.citizenship = citizenship;
            this.booking_id = booking_id;
            this.room_id = room_id;
        }
    }
}
