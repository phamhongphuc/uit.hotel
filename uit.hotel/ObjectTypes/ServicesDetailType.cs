using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class ServicesDetailType : ObjectGraphType<ServicesDetail>
    {
        public ServicesDetailType()
        {
            Name = nameof(ServicesDetail);
            Description = "Một chi tiết dịch vụ của Thông tin thuê phòng";

            Field(x => x.Id).Description("Id của chi tiết dịch vụ");
            Field(x => x.Time).Description("Thời gian tạo");
            Field(x => x.Number).Description("Số lượng");
            Field(x => x.Total).Description("Thành tiền");

            Field<NonNullGraphType<BookingType>>(
                nameof(ServicesDetail.Booking),
                "Thuộc thông tin thuê phòng nào",
                resolve: context => context.Source.Booking);
            Field<NonNullGraphType<ServiceType>>(
                nameof(ServicesDetail.Service),
                "Thuộc dịch vụ nào",
                resolve: context => context.Source.Service);
        }
    }

    public class ServicesDetailIdInput : InputType<ServicesDetail>
    {
        public ServicesDetailIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một chi tiết dịch vụ";

            Field(x => x.Id).Description("Id của chi tiết dịch vụ");
        }
    }

    public class ServicesDetailHouseKeepingInput : InputType<ServicesDetail>
    {
        public ServicesDetailHouseKeepingInput()
        {
            Name = "ServicesDetailHouseKeepingInput";

            Field(x => x.Number).Description("Số lượng");

            Field<NonNullGraphType<ServiceIdInput>>(
                nameof(ServicesDetail.Service),
                "Thuộc dịch vụ nào"
            );
        }
    }

    public class ServicesDetailCreateInput : InputType<ServicesDetail>
    {
        public ServicesDetailCreateInput()
        {
            Name = _Creation;

            Field(x => x.Number).Description("Số lượng");

            Field<NonNullGraphType<ServiceIdInput>>(
                nameof(ServicesDetail.Service),
                "Thuộc dịch vụ nào"
            );

            Field<NonNullGraphType<BookingIdInput>>(
                nameof(ServicesDetail.Booking),
                "Thuộc booking nào"
            );
        }
    }

    public class ServicesDetailUpdateInput : InputType<ServicesDetail>
    {
        public ServicesDetailUpdateInput()
        {
            Name = _Updation;

            Field(x => x.Id).Description("Id của chi tiết dịch vụ cần cập nhật");
            Field(x => x.Number).Description("Số lượng");

            Field<NonNullGraphType<ServiceIdInput>>(
                nameof(ServicesDetail.Service),
                "Thuộc dịch vụ nào"
            );
        }
    }
}
