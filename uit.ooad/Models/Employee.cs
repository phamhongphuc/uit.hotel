using System;
using Realms;

namespace uit.ooad.Models
{
    public class Employee : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public DateTimeOffset StartingDate { get; set; }
        public Access Access { get; set; }
    }
}
