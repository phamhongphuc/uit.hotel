using Realms;

namespace uit.ooad.Models
{
    public class HouseKeeping : RealmObject
    {
        public enum TypeEnum
        {
            MakeUpRoom, // Phòng cần làm sạch
            ExpectedArrival, // Phòng khách sắp đến
            ExpectedDeparture // Phòng khách sắp đi
        }
        public enum StatusEnum
        {
            Pending, // Chờ dọn
            Cleaning, // Đang dọn
            Cleaned, // Đã dọn
        }

        [PrimaryKey]
        public int Id { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public Employee Employee { get; set; }
        public Booking Booking { get; set; }
    }
}
