using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class Booking : RealmObject
    {
        [Ignored]
        public List<Patron> ListOfPatrons
        {
            set
            {
                if (IsManaged)
                    throw new Exception("Chỉ tạo setter cho trường dữ liệu này đối với đối tượng chưa được quản lý.");
                foreach (var patron in value)
                    Patrons.Add(patron.GetManaged());
            }
        }

        [PrimaryKey]
        public int Id { get; set; }
        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public int Status { get; set; }
        //sẽ tạo thêm 2 trường nhân viên nữa, để lưu nv đặt, nv check-in, nv check-out
        public Employee Employee { get; set; }
        public Bill Bill { get; set; }
        public Room Room { get; set; }
        public IList<Patron> Patrons { get; }

        [Backlink(nameof(HouseKeeping.Booking))]
        public IQueryable<HouseKeeping> HouseKeepings { get; }

        [Backlink(nameof(ServicesDetail.Booking))]
        public IQueryable<ServicesDetail> ServicesDetails { get; }
        public Booking GetManaged() => BookingBusiness.Get(Id);
    }
}
