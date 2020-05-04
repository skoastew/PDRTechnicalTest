using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PDR.PatientBooking.Data;
using PDR.PatientBookingApi.Controllers;

namespace PDR.PatientBookingApi.Services
{
    public interface IBookingService
    {
        object GetBookings(PatientBookingContext ctx, int doctorId, string daystring = null);
    }

    public class BookingService : IBookingService
    {
        public dynamic GetBookings(PatientBookingContext ctx, int doctorId, string daystring = null)
        {
            var bookings = ctx.Order.ToList();

            var bookings2 = bookings.Where(x => x.DoctorId == doctorId).ToList();

            if (daystring != null)
            {
                var time = DateTime.Parse(daystring);
                if (time > DateTime.Now)
                Console.WriteLine(doctorId.ToString() + " has requested bookings in the past");
                bookings2 = bookings.Where(x => x.StartTime > time).ToList();
                if (time < DateTime.Now)
                {
                    bookings2 = bookings.Where(i => i.EndTime < time).ToList();
                }
            }

            var bookings3 = new Results();
            for (var i = 0; i < bookings2.Count(); i++)
            {
                bookings3.Add(new Result());
                bookings3[i].DoctorId = bookings2[i].DoctorId;
                bookings3[i].StartTime = bookings2[i].StartTime;
                bookings3[i].EndTime = bookings2[i].StartTime;
                bookings3[i].PatientId = bookings2[i].PatientId;
                bookings3[i].SurgeryType = (int)bookings2[i].GetSurgeryType();
            }

            var bookings4 = bookings3.OrderBy(x => x.StartTime);
            return bookings4;
        }

        public class Results : List<Result> { }

        public class Result
        {
            public Guid Id { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public long PatientId { get; set; }
            public long DoctorId { get; set; }
            public int SurgeryType { get; set; }

        }
    }
}
