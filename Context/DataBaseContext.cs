using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IT_kursach_1.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Employee> Staff { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<OrderedService> OrderedServices { get; set; }
        public DbSet<BookingInfo> BookingsInfo { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BookingInfo>(bi => { bi.HasNoKey(); bi.ToView("BookingsInfo"); });
            mb.Entity<Employee>().Property(e => e.fire_date).IsRequired(false);
            base.OnModelCreating(mb);
        }
    }
}