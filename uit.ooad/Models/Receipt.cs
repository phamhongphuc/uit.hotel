using System;
using Realms;

namespace uit.ooad.Models
{
    public class Receipt : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public long Money { get; set; }
        public DateTimeOffset Time { get; set; }
        public int TypeOfPayment { get; set; }
        public string BankAccountNumber { get; set; }
        public Bill Bill { get; set; }
        public Employee Employee { get; set; }
    }
}
