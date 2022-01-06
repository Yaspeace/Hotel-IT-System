using IT_kursach_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IT_kursach_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataBaseContext dbc;

        public HomeController(ILogger<HomeController> logger, DataBaseContext _dbc)
        {
            _logger = logger;
            dbc = _dbc;
        }
        public IActionResult Index()
        {
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            return View();
        }

        public IActionResult Chat()
        {
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            return View();
        }

        public IActionResult Reviews()
        {
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            return View();
        }

        public IActionResult Leadership()
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            return View();
        }

        public IActionResult Rooms()
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            return View();
        }

        public IActionResult Services()
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            return View();
        }
        public RedirectResult Booking()
        {
            if (GlobalParams.IsEntered)
                return Redirect("Booking1");
            else
                return Redirect("BookingCancel");
        }
        public IActionResult BookingCancel()
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            return View();
        }
        public IActionResult Booking1()
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            GlobalParams.curBooking = new Booking();
            return View();
        }

        public IActionResult Booking2(DateTime check_in, DateTime check_out, int category)
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            GlobalParams.curBooking.check_in_date = check_in;
            GlobalParams.curBooking.check_out_date = check_out;
            var subcats = dbc.Subcategories.Where(sc => sc.category == category).ToList();
            ViewBag.Subcats = subcats;
            return View();
        }
        public IActionResult Booking3(int subcat)
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            List<Room> rooms = dbc.Rooms.Where(r => r.subcategory == subcat && r.status == "свободен").ToList();
            ViewBag.EnabledRooms = rooms;
            int adultNum = dbc.Subcategories.Find(subcat).capasity;
            ViewBag.AdNum = adultNum;
            return View();
        }
        public IActionResult Booking4(int adults, int childs, int roomNum)
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            GlobalParams.curBooking.adult = adults;
            GlobalParams.curBooking.childs = childs;
            GlobalParams.curBooking.room_number = roomNum;
            GlobalParams.curBooking.days = (GlobalParams.curBooking.check_out_date - GlobalParams.curBooking.check_in_date).Days;
            Room rom = dbc.Rooms.Find(GlobalParams.curBooking.room_number);
            Subcategory scat = dbc.Subcategories.Find(rom.subcategory);
            Category cat = dbc.Categories.Find(scat.category);
            List<Service> EnabledServices = dbc.Services.Where(s => s.enabled_category <= cat.category_id).ToList();
            ViewBag.Servs = EnabledServices;
            return View();
        }

        public IActionResult Booking5(int[] services)
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            GlobalParams.servs = services;
            ViewBag.adults = GlobalParams.curBooking.adult;
            ViewBag.countries = dbc.Countries.ToList();
            return View();
        }

        public IActionResult Payment(Guest[] guests)
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            GlobalParams.guests = guests;
            return View();
        }
        
        public RedirectResult Pay()
        {
            GlobalParams.curBooking.booking_date = DateTime.Now;
            GlobalParams.curBooking.client_code = dbc.Clients.Where(cl => cl.login == GlobalParams.cur_user_login).First().client_id;
            Room rom = dbc.Rooms.Find(GlobalParams.curBooking.room_number);
            GlobalParams.curBooking.status = "ok";
            Subcategory scat = dbc.Subcategories.Find(rom.subcategory);
            GlobalParams.curBooking.summ = GlobalParams.curBooking.days * scat.price;
            List<Service> srvs = new List<Service>();
            foreach (var serv in GlobalParams.servs)
            {
                Service s = dbc.Services.Find(serv);
                srvs.Add(s);
                GlobalParams.curBooking.summ += (decimal)(GlobalParams.curBooking.days * s.price);
            }
            dbc.Bookings.Add(GlobalParams.curBooking);
            Booking added = dbc.Bookings.OrderBy(b => b.booking_id).Last();

            foreach (var serv in srvs)
            {
                int last_id = dbc.OrderedServices.OrderBy(s => s.id).Last().id;
                dbc.OrderedServices.Add(new OrderedService(last_id + 1, added.booking_id, serv.id));
            }
            foreach (var g in GlobalParams.guests)
            {
                int lid = dbc.Guests.OrderBy(gst => gst.id).Last().id;
                g.room_id = GlobalParams.curBooking.room_number;
                g.booking_id = added.booking_id;
                g.id = lid + 1;
                dbc.Guests.Add(g);
            }
            dbc.SaveChanges();
            return Redirect("BookingFinal");
        }
        public IActionResult BookingFinal()
        {
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            return View(GlobalParams.curBooking);
        }

        public IActionResult Entering(bool EnterAsAdmin, bool EnteringInvalid)
        {
            ViewBag.EnterAsAdmin = EnterAsAdmin;
            ViewBag.EnteringInvalid = EnteringInvalid;
            return View();
        }

        public IActionResult Registration(bool passwordsAreSame)
        {
            ViewBag.NotSamePasswords = !passwordsAreSame;
            return View();
        }

        [HttpGet]
        public IActionResult UserLK()
        {
            Client cl = dbc.Clients.Where(cl => cl.login == GlobalParams.cur_user_login).First();
            ViewBag.cur_cl = cl;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            return View();
        }

        [HttpPost]
        public IActionResult UserLK(string surname, string name, string patronym, string passport, string phone, string email)
        {
            if(name != null && name != "" && surname != null && surname != "" && patronym != null && patronym != "" && passport != null && passport != "" && phone != null && phone != "" && email != null && email != "")
            {
                int id = dbc.Clients.Where(cl => cl.login == GlobalParams.cur_user_login).First().client_id;
                Client cl = dbc.Clients.Find(id);
                cl.client_name = name;
                cl.client_surname = surname;
                cl.client_patronym = patronym;
                cl.passport_number = passport;
                cl.phone = phone;
                cl.email = email;
                dbc.SaveChanges();
                SetCurUser(cl);
            }

            Client clnt = dbc.Clients.Where(cl => cl.login == GlobalParams.cur_user_login).First();
            ViewBag.cur_cl = clnt;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;

            return View();
        }
        public RedirectResult CancelBooking(int booking_id)
        {
            dbc.Bookings.Find(booking_id).status = "cancel";
            dbc.SaveChanges();
            int clid = dbc.Clients.Where(cl => cl.login == GlobalParams.cur_user_login).First().client_id;
            return Redirect($"UserBookings?id={clid}");
        }
        public IActionResult UserBookings(int id)
        {
            ViewBag.clnt = dbc.Clients.Find(id);
            List<BookingInfo> cl_bookings = dbc.BookingsInfo.Where(b => b.cl_id == id && b.status == "ok").ToList();
            List<OrderedService> orderedServs = dbc.OrderedServices.ToList();
            ViewBag.clientBookings = cl_bookings;
            List<Service> servs = dbc.Services.ToList();
            UserBookingsModel ubm = new UserBookingsModel { services = servs, oservices = orderedServs };

            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;

            return View(ubm);
        }
        public IActionResult BookingHist(int id)
        {
            ViewBag.clnt = dbc.Clients.Find(id);
            List<BookingInfo> cl_bookings = dbc.BookingsInfo.Where(b => b.cl_id == id && b.status != "ok").ToList();
            List<OrderedService> orderedServs = dbc.OrderedServices.ToList();
            ViewBag.clientBookings = cl_bookings;
            List<Service> servs = dbc.Services.ToList();
            UserBookingsModel ubm = new UserBookingsModel { services = servs, oservices = orderedServs };

            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;

            return View(ubm);
        }
        public IActionResult AdminLK()
        {
            int todayYear = DateTime.Today.Year;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;

            //Далее- получение данных для статистики
            List<Booking> curbookings = dbc.Bookings.Where(booking => booking.check_in_date.Year == todayYear && booking.status != "cancel").ToList();
            List<Booking> prevbookings = dbc.Bookings.Where(booking => booking.check_in_date.Year == todayYear - 1 && booking.status != "cancel").ToList();
            string[] month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            ViewBag.Year = todayYear;
            ViewBag.Month = month;
            
            Dictionary<string, decimal[]> summs = new Dictionary<string, decimal[]>();
            foreach (string mon in month)
                summs.Add(mon, new decimal[] { 0, 0 });
            foreach(var booking in curbookings)
                summs[month[booking.check_in_date.Month - 1]][0] += booking.summ;
            foreach (var booking in prevbookings)
                summs[month[booking.check_in_date.Month - 1]][1] += booking.summ;
            ViewBag.Summs = summs;

            var guests = dbc.Guests.AsEnumerable();
            var countCurYear = from booking in curbookings
                        join guest in guests
                        on booking.booking_id equals guest.booking_id
                        group guests by booking.check_in_date.Month into g
                        select new { Month = g.Key, Count = g.Count() };
            var countPrevYear = from booking in prevbookings
                                join guest in guests
                                on booking.booking_id equals guest.booking_id
                                group guests by booking.check_in_date.Month into g
                                select new { Month = g.Key, Count = g.Count() };

            Dictionary<string, int[]> counts = new Dictionary<string, int[]>();
            foreach (string mon in month)
                counts.Add(mon, new int[] { 0, 0 });
            foreach(var row in countCurYear)
                counts[month[row.Month - 1]][0] = row.Count;
            foreach(var row in countPrevYear)
                counts[month[row.Month - 1]][1] = row.Count;
            ViewBag.Counts = counts;

            return View();
        }
        [HttpGet]
        public IActionResult BookingTable()
        {
            BookingTableModel model = new BookingTableModel();
            model.BookingsInfo = dbc.BookingsInfo.ToList().Where(b => (DateTime.Now - b.booking_date).TotalDays <= 365).ToList();
            model.Clients = dbc.Clients.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult BookingTable(string toDo, int booking_id)
        {
            switch(toDo)
            {
                case "tocancel":
                    dbc.Bookings.Find(booking_id).status = "cancel";
                    dbc.SaveChanges();
                    break;
                case "took":
                    dbc.Bookings.Find(booking_id).status = "ok";
                    dbc.SaveChanges();
                    break;
                case "tobegin":
                    dbc.Bookings.Find(booking_id).status = "begin";
                    dbc.SaveChanges();
                    break;
                case "toend":
                    dbc.Bookings.Find(booking_id).status = "end";
                    dbc.SaveChanges();
                    break;
            }

            BookingTableModel model = new BookingTableModel();
            model.BookingsInfo = dbc.BookingsInfo.ToList().Where(b => (DateTime.Now - b.booking_date).TotalDays <= 365).ToList();
            model.Clients = dbc.Clients.ToList();
            return View(model);
        }
        public RedirectResult RegProcess(string surname, string name, string patronym, string userName, string password, string checkPassword)
        {
            //Если какое-то из полей не заполнено
            if (name == "" || name == null || surname == "" || surname == null || userName == "" || userName == null || password == "" || password == null || checkPassword == "" || checkPassword == null)
                return Redirect("Registration?passwordsAreSame=false");
            if (password != checkPassword) //Если пароли не совпадают
                return Redirect("Registration?passwordsAreSame=false");
            if (dbc.Clients.Any(cl => cl.login == userName)) //Если уже есть пользователь с таким логином
                return Redirect("Registration?passwordsAreSame=false"); //Пока что будет выбрасывать на страницу регистрации и говорить что пароли совпадают
            //Если таки всё в порядке
            Client newcl = new Client();
            newcl.client_name = name;
            newcl.client_surname = surname;
            newcl.client_patronym = patronym;
            newcl.login = userName;
            newcl.password = password;
            newcl.citizenship = 643;
            dbc.Clients.Add(newcl);
            dbc.SaveChanges();
            GlobalParams.IsEntered = true;
            SetCurUser(newcl);
            return Redirect("UserLK");
        }
        public IActionResult BookingMoreInfo(int booking_id)
        {
            BookingMoreInfoModel model = new BookingMoreInfoModel();
            model.Guests = dbc.Guests.Where(g => g.booking_id == booking_id).ToList();
            model.GuestCitizens = new List<Country>();
            foreach(var g in model.Guests)
            {
                Country c = dbc.Countries.Where(c => c.country_code == g.citizenship).First();
                if (!model.GuestCitizens.Contains(c))
                    model.GuestCitizens.Add(c);
            }
            model.Services = new List<Service>();
            List<OrderedService> oservs = dbc.OrderedServices.Where(os => os.booking_id == booking_id).ToList();
            foreach (var oserv in oservs)
            {
                Service s = dbc.Services.Where(serv => serv.id == oserv.service_id).First();
                model.Services.Add(s);
            }
            return View(model);
        }
        private void SetCurUser(Client cur_user)
        {
            GlobalParams.cur_user_login = cur_user.login;
            GlobalParams.cur_user_password = cur_user.password;
            GlobalParams.cur_user_name = cur_user.client_name;
            GlobalParams.cur_user_surname = cur_user.client_surname;
            GlobalParams.cur_user_patronym = cur_user.client_patronym;
        }

        public RedirectResult EnterProcess(string login, string password, bool asAdmin)
        {
            if (!asAdmin)
            {
                try
                {
                    Client client = dbc.Clients.First(c => c.login == login);
                    if (client.password == password) //Если введённый пароль верный
                    {
                        SetCurUser(client);
                        GlobalParams.IsEntered = true;
                        return Redirect("UserLK");
                    }
                    else
                        return Redirect("Entering?EnterAsAdmin=false&EnteringInvalid=true");
                }
                catch (InvalidOperationException)
                {
                    return Redirect("Entering?EnterAsAdmin=false&EnteringInvalid=true");
                }
            }
            else
            {
                try
                {
                    Administrator admin = dbc.Administrators.First(a => a.login == login);
                    if (admin.password == password) //Если введённый пароль верный
                    {
                        GlobalParams.cur_user_name = admin.name;
                        GlobalParams.cur_user_surname = admin.surname;
                        GlobalParams.cur_user_patronym = admin.patronym;
                        GlobalParams.cur_user_login = admin.login;
                        GlobalParams.cur_user_password = admin.password;
                        GlobalParams.IsEntered = true;
                        GlobalParams.EnteredAsAdmin = true;
                        return Redirect("AdminLK");
                    }
                    else
                        return Redirect("Entering?EnterAsAdmin=true&EnteringInvalid=true");
                }
                catch (InvalidOperationException)
                {
                    return Redirect("Entering?EnterAsAdmin=true&EnteringInvalid=true");
                }
            }
        }

        public IActionResult Staff()
        {
            StaffModel model = new StaffModel();
            model.Positions = dbc.Positions.ToList();
            model.Staff = dbc.Staff.ToList();
            return View(model);
        }

        public IActionResult StaffForUser()
        {
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;

            StaffModel model = new StaffModel();
            model.Positions = dbc.Positions.ToList();
            model.Staff = dbc.Staff.Where(s => s.status != "уволен").ToList();
            return View(model);
        }

        public IActionResult Npas()
        {
            ViewBag.Entered = GlobalParams.IsEntered;
            ViewBag.EnteredAsAdmin = GlobalParams.EnteredAsAdmin;
            ViewBag.cur_user_name = GlobalParams.cur_user_name;
            ViewBag.cur_user_patronym = GlobalParams.cur_user_patronym;
            return View();
        }

        public IActionResult ServiceTable()
        {
            ServiceTableModel model = new ServiceTableModel();
            model.Services = dbc.Services.ToList();
            model.Staff = dbc.Staff.ToList();
            return View(model);
        }

        public RedirectResult Quit()
        {
            GlobalParams.IsEntered = false;
            GlobalParams.EnteredAsAdmin = false;
            Client cl = new Client();
            SetCurUser(cl);
            return Redirect("Index");
        }

        [HttpPost]
        public JsonResult GetOptions(string category)
        {
            Category cat = dbc.Categories.Where(c => c.category_name == category).First();
            List<Subcategory> subcats = dbc.Subcategories.Where(s => s.category == cat.category_id).ToList();
            string options = "";
            foreach(var subcat in subcats)
                options += $"<option value=\"{subcat.name}\">{subcat.name}</option>";
            return Json(options);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
