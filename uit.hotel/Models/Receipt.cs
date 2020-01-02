using System;
using System.ComponentModel;
using System.Linq;
using Realms;
using uit.hotel.Businesses;
using uit.hotel.Queries.Helper;

namespace uit.hotel.Models
{
    public enum ReceiptKindEnum
    {
        [Description("Tiền mặt")] Cash,
        [Description("Momo")] Momo,
    }

    public enum ReceiptStatusEnum
    {
        [Description("Đang chờ")] Pending,
        [Description("Đã thanh toán")] Success,
        [Description("Có lỗi")] Error,
        [Description("Lỗi hệ thống")] SystemError,
    }

    public class Receipt : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Ignored]
        public ReceiptKindEnum Kind { get => (ReceiptKindEnum)KindRaw; set { KindRaw = (int)value; } }
        private int KindRaw { get; set; }

        public long Money { get; set; }
        public DateTimeOffset Time { get; set; }
        public Bill Bill { get; set; }
        public Employee Employee { get; set; }

        [Ignored]
        public ReceiptStatusEnum Status { get => (ReceiptStatusEnum)StatusRaw; set { StatusRaw = (int)value; } }
        private int StatusRaw { get; set; }

        // Momo
        [Required]
        public string PayUrl { get; set; }
        [Required]
        public string StatusText { get; set; }

        public string OrderId => $"{Time.ToAlphabet()}-{Id}";
        public string RequestId => OrderId;

        public string OrderInfo => $"Thuê phòng {Rooms}. {Dates}.";
        public string ExtraData => $"id={Id}&billId={Bill.Id}";

        private string Rooms => String.Join(", ",Bill.Bookings.ToArray().Select(b => b.Room.Name));
        private string Dates => $"Từ {FirstBooking.CheckInTime.Format()} đến {FirstBooking.CheckOutTime.Format()}";
        private Booking FirstBooking => Bill.Bookings.ToArray()[0];

        public Receipt GetManaged()
        {
            if (IsManaged) return this;

            var receipt = ReceiptBusiness.Get(Id);
            if (receipt == null)
                throw new Exception("Mã phiếu thu không tồn tại");

            return receipt;
        }
    }
}
