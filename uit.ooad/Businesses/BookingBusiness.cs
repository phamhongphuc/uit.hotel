using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class BookingBusiness
    {
        public static Task<Booking> CheckIn(Employee employee, int bookingId)
        {
            var bookingInDatabase = Get(bookingId);
            if (bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại");
            if (bookingInDatabase.Status != (int) Booking.StatusEnum.Booked)
                throw new Exception("Phòng đã được check-in, không thể check-in lại.");

            var houseKeeping = new HouseKeeping();
            houseKeeping.Type = (int) HouseKeeping.TypeEnum.ExpectedArrival;
            houseKeeping.Status = (int) HouseKeeping.StatusEnum.Pending;
            houseKeeping.Booking = bookingInDatabase;

            return BookingDataAccess.CheckIn(employee, bookingInDatabase, houseKeeping);
        }

        public static Task<Booking> RequestCheckOut(Employee employee, int bookingId)
        {
            var bookingInDatabase = Get(bookingId);

            if (bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại");
            if (bookingInDatabase.Status != (int) Booking.StatusEnum.CheckedIn)
                throw new Exception("Không thể yêu cầu trả phòng");

            var houseKeeping = new HouseKeeping();
            houseKeeping.Type = (int) HouseKeeping.TypeEnum.ExpectedDeparture;
            houseKeeping.Status = (int) HouseKeeping.StatusEnum.Pending;
            houseKeeping.Booking = bookingInDatabase;

            return BookingDataAccess.RequestCheckOut(employee, bookingInDatabase, houseKeeping);
        }

        public static Task<Booking> CheckOut(Employee employee, int bookingId)
        {
            var bookingInDatabase = Get(bookingId);
            if(bookingInDatabase == null)
                throw new Exception("Mã Booking không tồn tại.");
            if(bookingInDatabase.Status != (int)Booking.StatusEnum.RequestedCheckOut)
                throw new Exception("Không thể Check-out.");
            if(!bookingInDatabase.EmployeeCheckOut.Equals(employee))
                throw new Exception("Nhân viên không được phép check-out.");
                
            return BookingDataAccess.CheckOut(bookingInDatabase);
        }

        public static Booking Get(int bookingId) => BookingDataAccess.Get(bookingId);
        public static IEnumerable<Booking> Get() => BookingDataAccess.Get();
    }
}
