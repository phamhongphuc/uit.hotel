using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

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
            Field(x => x.BankAccountNumber, true).Description("Số tài khoản ngân hàng của khách");

            Field<NonNullGraphType<BillType>>(
                nameof(Receipt.Bill),
                resolve: context => context.Source.Bill,
                description: "Phiếu thu thuộc hóa đơn nào"
            );

            Field<NonNullGraphType<EmployeeType>>(
                nameof(Receipt.Employee),
                resolve: context => context.Source.Employee,
                description: "Nhân viên tạo phiếu thu"
            );
        }
    }

    public class ReceiptCreateInput : InputType<Receipt>
    {
        public ReceiptCreateInput()
        {
            Field(x => x.Id).Description("Id của phiếu thu");
            Field(x => x.Money).Description("Số tiền đã thu");
            Field(x => x.Time).Description("Thời gian tạo phiếu thu");
            Field(x => x.TypeOfPayment).Description("Kiểu thanh toán (tiền mặt hoặc chuyển khoản)");
            Field(x => x.BankAccountNumber, true).Description("Số tài khoản ngân hàng của khách");

            Field<BillIdInput>(
                nameof(Receipt.Bill),
                "Thuộc hóa đơn"
            );

            Field<EmployeeIdInput>(
                nameof(Receipt.Employee),
                "Nhân viên tạo phiếu thu"
            );
        }
    }
}
