using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class Patron : RealmObject
    {
        [Ignored]
        public List<string> ListOfPhoneNumbers
        {
            set
            {
                if (IsManaged)
                    throw new Exception("Chỉ tạo setter cho trường dữ liệu này đối với đối tượng chưa được quản lý.");
                foreach (var phoneNumber in value)
                    PhoneNumbers.Add(phoneNumber);
            }
        }

        [Indexed]
        [PrimaryKey]
        public int Id { get; set; }
        // Định danh: Số an sinh xã hội / Số chứng minh nhân dân / Số passport
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public IList<string> PhoneNumbers { get; }
        public string Nationality { get; set; } // Quốc tịch
        public string Domicile { get; set; } // Nguyên quán
        public string Residence { get; set; } // Thường trú
        public string Company { get; set; }
        public string Note { get; set; }
        public PatronKind PatronKind { get; set; }

        [Backlink(nameof(Bill.Patron))]
        public IQueryable<Bill> Bills { get; }

        [Backlink(nameof(Booking.Patrons))]
        public IQueryable<Booking> Bookings { get; }

        public Patron GetManaged()
        {
            var patronInDatabase = PatronBusiness.Get(Id);
            if (patronInDatabase == null)
                throw new Exception("Không tìm thấy khách hàng có Id là " + Id);
            return patronInDatabase;
        }
    }
}
