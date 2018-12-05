using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class ReceiptType : ObjectGraphType<Receipt>
    {
        public ReceiptType()
        {
            Name = nameof(Receipt);
            Description = "Phiếu thu";

            Field(x => x.Id).Description("Id của phiếu thu");
            Field(x => x.Money).Description("Số tiền đã thu");
            Field(x => x.Time).Description("Thời gian tạo phiếu thu");
            Field(x => x.TypeOfPayment).Description("Kiểu thanh toán (tiền mặt hoặc chuyển khoản)");
            Field(x => x.BankAccountNumber).Description("Số tài khoản ngân hàng của khách");

            Field<BillType>(nameof(Receipt.Bill), resolve: context => context.Source.Bill, description: "Phiếu thu thuộc hóa đơn nào");
            Field<EmployeeType>(nameof(Receipt.Employee), resolve: context => context.Source.Employee, description: "Nhân viên tạo phiếu thu");
        }
    }
}
