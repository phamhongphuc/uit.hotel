using System;
using Realms;

namespace uit.ooad.Models
{
    public class Patron : RealmObject
    {
        [Indexed]
        [PrimaryKey]
        public string Identification { get; set; }    // Định danh: Số an sinh xã hội / Số chứng minh nhân dân / Số passport
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public DateTimeOffset PhoneNumber { get; set; }
        public string Nationality { get; set; } // Quốc tịch
        public string Domicile { get; set; }    // Nguyên quán
        public string Residence { get; set; }   // Thường trú
        public string Company { get; set; }
        public string Note { get; set; }
    }
}
