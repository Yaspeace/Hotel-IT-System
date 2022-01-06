using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_kursach_1.Models
{
    public static class GlobalParams
    {
        public static bool IsEntered = false;
        public static bool EnteredAsAdmin = false;
        public static string cur_user_login = string.Empty;
        public static string cur_user_password = string.Empty;
        public static string cur_user_name = string.Empty;
        public static string cur_user_surname = string.Empty;
        public static string cur_user_patronym = string.Empty;
        public static Booking curBooking = null;
        public static int[] servs;
        public static Guest[] guests;
    }
}
