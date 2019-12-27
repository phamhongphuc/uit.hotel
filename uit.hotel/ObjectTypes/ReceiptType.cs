using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class ReceiptKindEnumType : EnumerationGraphType<ReceiptKindEnum>
    {
        public ReceiptKindEnumType()
        {
            Name = nameof(ReceiptKindEnum);
            Description = "Loại phiếu thu";
        }
    }

    public class ReceiptStatusEnumType : EnumerationGraphType<ReceiptStatusEnum>
    {
        public ReceiptStatusEnumType()
        {
            Name = nameof(ReceiptStatusEnum);
            Description = "Loại phiếu thu";
        }
    }

    public class ReceiptType : ObjectGraphType<Receipt>
    {
        public ReceiptType()
        {
            Name = nameof(Receipt);
            Description = "Phiếu thu";

            Field(x => x.Id).Description("Id của phiếu thu");
            Field(x => x.Money).Description("Số tiền đã thu");
            Field(x => x.Time).Description("Thời gian tạo phiếu thu");
            Field(x => x.PayUrl).Description("Đường dẫn thanh toán");
            Field(x => x.StatusText).Description("Trạng thái của phiếu thu");
            Field(x => x.OrderInfo).Description("Thông tin thanh toán");
            Field(x => x.ExtraData).Description("Thông tin thêm");

            Field<NonNullGraphType<ReceiptStatusEnumType>>(
                nameof(Receipt.Status),
                "Trạng thái thanh toán"
            );
            Field<NonNullGraphType<ReceiptKindEnumType>>(
                nameof(Receipt.Kind),
                "Loại thanh toán"
            );
            Field<NonNullGraphType<BillType>>(
                nameof(Receipt.Bill),
                "Phiếu thu thuộc hóa đơn nào",
                resolve: context => context.Source.Bill
            );
            Field<NonNullGraphType<EmployeeType>>(
                nameof(Receipt.Employee),
                "Nhân viên tạo phiếu thu",
                resolve: context => context.Source.Employee
            );
        }
    }

    public class ReceiptCreateInput : InputType<Receipt>
    {
        public ReceiptCreateInput()
        {
            Field(x => x.Money).Description("Số tiền đã thu");

            Field<NonNullGraphType<BillIdInput>>(
                nameof(Receipt.Bill),
                "Thuộc hóa đơn"
            );
            Field<NonNullGraphType<ReceiptKindEnumType>>(
                nameof(Receipt.Kind),
                "Loại thanh toán"
            );
        }
    }

    public class ReceiptIdInput : InputType<Receipt>
    {
        public ReceiptIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một phiếu thu";

            Field(x => x.Id).Description("Id của phiếu thu");
        }
    }
}
