using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class ReceiptType : ObjectGraphType<Receipt>
    {
        public ReceiptType()
        {
            Name = "Receipt";
            Description = "Phiếu thu";

            Field(x => x.Id).Description("Id của phiếu thu");
            Field(x => x.Money).Description("Số tiền đã thu");
            Field(x => x.Time).Description("Thời gian tạo phiếu thu");
            Field(x => x.TypeOfPayment).Description("Kiểu thanh toán (tiền mặt hoặc chuyển khoản)");
            Field(x => x.BankAccountNumber).Description("Số tài khoản ngân hàng của khách");
            Field(x => x.Bill).Description("Phiếu thu thuộc hóa đơn nào");
            Field(x => x.Employee).Description("Nhân viên tạo phiếu thu");
        }
    }
}
