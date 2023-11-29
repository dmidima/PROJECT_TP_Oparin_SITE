
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SITE.Data.Identity;
using System.IO.Pipelines;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace SITE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        //internal readonly IEnumerable<object> DetailsRoute;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Student>().Property(z => z.Name).HasMaxLength(100);

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "First",
                    BirthData = DateTime.Now.AddYears(-20),
                    Prise = 999.99m,
                });

            builder.Entity<DetailsRoute>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<DetailsRoute>().Property(z => z.Name).HasMaxLength(100);
            builder.Entity<DetailsRoute>().HasData(
                new DetailsRoute
                {

                    Id = 1,
                    Name ="Владимир",
                    Day = "пн",
                    DepartureTime = "14:30, 16:45, 19:00",
                    RouteNumber = 530,
                    Transport = "Автобус",
                    TravelTime = "1час",
                    Distance = "100км",
                    Prise =350.00m,
                });

            builder.Entity<Booking>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Booking>().Property(z => z.Seat).HasMaxLength(100);
            builder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    DateBook = new DateTime(2023, 11, 28),
                    TimeBook = "14:00",
                    Seat = 5,
                    otkyda = "Владимир",
                    kyda = "Иваново",
                    sostoania = "Подтвержден",
                    Email = "oparins@gamil.com",
                });

            builder.Entity<ReservedSeat>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<ReservedSeat>().HasData(
                new ReservedSeat
                {
                    Id = 1,
                    Date = new DateTime(2023, 11, 29),
                    DataTimeRoute = "9:00",
                    SeatNumber = 1,
                    NameRoute = "Владимир-Иваново",
                });

            builder.Entity<Transport>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Transport>().HasData(
                new Transport
                {
                    Id = 1,
                    Brand = "Мерседес",
                    Number = "C999CC",
                    PlaceCount = 16,
                    RouteNum = "570 450 230",
                });

            builder.Entity<Personal>().Property(z => z.Id).UseIdentityColumn();
            builder.Entity<Personal>().HasData(
                new Personal
                {
                    Id = 1,
                    Surname = "Опарин",
                    Name = "Дима",
                    Job = "Контроллер",
                    WorkTime = "8:00-17:00",
                });



            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<DetailsRoute> DetailsRoutes { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        //public object DetailsRoute { get; internal set; }

        public DbSet<ReservedSeat> ReservedSeats { get; set; }
        public object ReservedSeat { get; internal set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<Personal> Personals { get; set; }

    }
}