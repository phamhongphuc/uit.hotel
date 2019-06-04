using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
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
            Field(x => x.BankAccountNumber, true).Description("Số tài khoản ngân hàng của khách");

            Field<NonNullGraphType<BillType>>(
                nameof(Receipt.Bill),
                "Phiếu thu thuộc hóa đơn nào",
                resolve: context => context.Source.Bill);

            Field<NonNullGraphType<EmployeeType>>(
                nameof(Receipt.Employee),
                "Nhân viên tạo phiếu thu",
                resolve: context => context.Source.Employee);
        }
    }

    public class ReceiptCreateInput : InputType<Receipt>
    {
        public ReceiptCreateInput()
        {
            Field(x => x.Money).Description("Số tiền đã thu");
            Field(x => x.BankAccountNumber, true).Description("Số tài khoản ngân hàng của khách");

            Field<NonNullGraphType<BillIdInput>>(
                nameof(Receipt.Bill),
                "Thuộc hóa đơn"
            );
        }
    }
}
