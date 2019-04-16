using Realms;

namespace uit.hotel.Models
{
    public class HouseKeeping : RealmObject
    {
        public enum StatusEnum
        {
            Pending, // Chờ dọn
            Cleaning, // Đang dọn
            Cleaned // Đã dọn
        }

        public enum TypeEnum
        {
            MakeUpRoom, // Phòng cần làm sạch
            ExpectedArrival, // Phòng khách sắp đến
            ExpectedDeparture // Phòng khách sắp đi
        }

        [PrimaryKey]
        public int Id { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public Employee Employee { get; set; }
        public Booking Booking { get; set; }
    }
}
