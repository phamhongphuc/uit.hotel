using Realms;

namespace uit.ooad.Models
{
    public class HouseKeeping : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Type { get; set; }
        public Employee Employee { get; set; }
        public Booking Booking { get; set; }
    }
}