using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class BillType : ObjectGraphType<Bill>
    {
        public BillType()
        {
            Name = nameof(Bill);
            Description = "Một phiếu hóa đơn của khách hàng";

            Field(x => x.Id).Description("Id của hóa đơn");
            Field(x => x.Time).Description("Thời điểm in hóa đơn");
            Field<PatronType>(nameof(Bill.Patron), resolve: context => context.Source.Patron);
            // Field(x => x.Patron).Description("Thông tin khách hàng thanh toán hóa đơn");
            // Field(x => x.Employee).Description("Thông tin nhân viên nhận thanh toán hóa đơn");
            Field<ListGraphType<ReceiptType>>(
                "Receipts",
                resolve: context =>
                    context.Source.Receipts.ToList(),
                description: "Danh sách các biên nhận cho hóa đơn");

            Field<ListGraphType<BookingType>>(
                "Bookings",
                resolve: context => context.Source.Bookings.ToList(),
                description: "Danh sách các thông tin đặt trước của hóa đơn"
            );
        }
    }
}
