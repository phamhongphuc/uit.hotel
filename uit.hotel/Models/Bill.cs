using System;
using System.ComponentModel;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
{
    public enum BillStatusEnum
    {
        [Description("Đang chờ")] Pending,
        [Description("Đã thanh toán")] Success,
        [Description("Đã hủy")] Cancel,
    }

    public class Bill : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public Patron Patron { get; set; }
        public Employee Employee { get; set; }

        [Ignored]
        public BillStatusEnum Status { get => (BillStatusEnum)StatusRaw; set { StatusRaw = (int)value; } }
        private int StatusRaw { get; set; }

        [Backlink(nameof(Receipt.Bill))]
        public IQueryable<Receipt> Receipts { get; }

        [Backlink(nameof(Booking.Bill))]
        public IQueryable<Booking> Bookings { get; }

        public long Discount { get; set; }
        public long TotalPrice { get; private set; }
        public long TotalReceipts { get; private set; }

        public void Calculate()
        {
            CalculateTotalPrice();
            CalculateTotalReceipts();
        }

        public void CalculateTotalPrice()
        {
            long total = 0;
            foreach (var b in Bookings) total += b.Total;
            TotalPrice = total;
        }

        public void CalculateTotalReceipts()
        {
            long total = 0;
            foreach (var receipt in Receipts)
                if (receipt.Status == ReceiptStatusEnum.Success) total += receipt.Money;
            TotalReceipts = total;
        }

        public Bill GetManaged()
        {
            var bill = BillBusiness.Get(Id);
            if (bill == null)
                throw new Exception("Mã hóa đơn không tồn tại");
            return bill;
        }
    }
}
