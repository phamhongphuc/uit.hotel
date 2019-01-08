using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

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
            Field(x => x.Total).Description("Tổng giá trị hóa đơn");
            Field(x => x.TotalReceipts).Description("Tổng giá trị các phiếu thu");

            Field<NonNullGraphType<PatronType>>(
                nameof(Bill.Patron),
                "Thông tin khách hàng thanh toán hóa đơn",
                resolve: context => context.Source.Patron);

            Field<EmployeeType>(
                nameof(Bill.Employee),
                "Thông tin nhân viên nhận thanh toán hóa đơn",
                resolve: context => context.Source.Employee);

            Field<ListGraphType<ReceiptType>>(
                nameof(Bill.Receipts),
                "Danh sách các biên nhận cho hóa đơn",
                resolve: context => context.Source.Receipts.ToList());

            Field<ListGraphType<BookingType>>(
                nameof(Bill.Bookings),
                "Danh sách các thông tin đặt trước của hóa đơn",
                resolve: context => context.Source.Bookings.ToList());
        }
    }

    public class BillIdInput : InputType<Bill>
    {
        public BillIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một hóa đơn";

            Field(x => x.Id).Description("Id của hóa đơn");
        }
    }

    public class BillCreateInput : InputType<Bill>
    {
        public BillCreateInput()
        {
            Field<PatronIdInput>(
                nameof(Bill.Patron),
                "Khách hàng"
            );
        }
    }
}
