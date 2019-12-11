using System.Linq;
using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class BillType : ObjectGraphType<Bill>
    {
        public BillType()
        {
            Name = nameof(Bill);
            Description = "Một phiếu hóa đơn của khách hàng";

            Field(x => x.Id).Description("Id của hóa đơn");
            Field(x => x.Time).Description("Thời điểm in hóa đơn");
            Field(x => x.TotalPrice).Description("Tổng giá trị hóa đơn");
            Field(x => x.TotalReceipts).Description("Tổng giá trị các phiếu thu");
            Field(x => x.Discount).Description("Giảm giá");

            Field<NonNullGraphType<PatronType>>(
                nameof(Bill.Patron),
                "Thông tin khách hàng thanh toán hóa đơn",
                resolve: context => context.Source.Patron);

            Field<EmployeeType>(
                nameof(Bill.Employee),
                "Thông tin nhân viên nhận thanh toán hóa đơn",
                resolve: context => context.Source.Employee);

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<ReceiptType>>>>(
                nameof(Bill.Receipts),
                "Danh sách các biên nhận cho hóa đơn",
                resolve: context => context.Source.Receipts.ToList());

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BookingType>>>>(
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

    public class BillUpdateInput : InputType<Bill>
    {
        public BillUpdateInput()
        {
            Name = _Updation;
            Description = "Input để cập nhật thông tin một hóa đơn";

            Field(x => x.Id).Description("Id của hóa đơn");
            Field(x => x.Discount).Description("Giảm giá");

            Field<NonNullGraphType<PatronIdInput>>(
                nameof(Bill.Patron),
                "Thông tin khách hàng thanh toán hóa đơn"
            );
        }
    }

    public class BillCreateInput : InputType<Bill>
    {
        public BillCreateInput()
        {
            Field<NonNullGraphType<PatronIdInput>>(
                nameof(Bill.Patron),
                "Khách hàng"
            );
        }
    }
}
