using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_kursach_1.Models
{
    public class Booking
    {
        [Key]
        public int booking_id { get; set; }
        public int client_code { get; set; }
        public int room_number { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public DateTime booking_date { get; set; }
        public int days { get; set; }
        public decimal summ { get; set; }
        public string status { get; set; }
        public int adult { get; set; }
        public int childs { get; set; }

        public Booking()
        {
        }

        public Booking(int booking_id, int client_code, int room_number, DateTime check_in_date, DateTime check_out_date, DateTime booking_date, int days, decimal summ, string status, int adult, int childs)
        {
            this.booking_id = booking_id;
            this.client_code = client_code;
            this.room_number = room_number;
            this.check_in_date = check_in_date;
            this.check_out_date = check_out_date;
            this.booking_date = booking_date;
            this.days = days;
            this.summ = summ;
            this.status = status;
            this.adult = adult;
            this.childs = childs;
        }
    }
}
