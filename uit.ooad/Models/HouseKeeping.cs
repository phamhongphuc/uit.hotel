using Realms;

namespace uit.ooad.Models
{
    public class HouseKeeping : RealmObject
    {
        public enum TypeEnum
        {
            MakeUpRoom, // Phòng cần làm sạch
            ExpectedArrival, // Phòng khách sắp đến
            ExpectedDeparture // Phòng khách sáp đi
        }
        [PrimaryKey]
        public int Id { get; set; }
        public int Type { get; set; }
        public Employee Employee { get; set; }
        public Booking Booking { get; set; }
    }
}
