using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class BillType : ObjectGraphType<Bill>
    {
        public BillType()
        {
            Name = "Bill";
            Description = "Một phiếu hóa đơn của khách hàng";

            Field(x => x.Id).Description("Id của hóa đơn");
            Field(x => x.Time).Description("Thời điểm in hóa đơn");
            Field(x => x.Patron).Description("Thông tin khách hàng thanh toán hóa đơn");
            Field(x => x.Employee).Description("Thông tin nhân viên nhận thanh toán hóa đơn");
            // Field(x => x.Receipts).Description("Danh sách các biên nhận cho hóa đơn");
            // Field(x => x.Bookings).Description("Danh sách các thông tin đặt trước của hóa đơn");
        }
    }
}