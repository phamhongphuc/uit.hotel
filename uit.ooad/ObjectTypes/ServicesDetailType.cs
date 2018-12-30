using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
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
                resolve: context => context.Source.Booking,
                description: "Thuộc thông tin thuê phòng nào");
            Field<NonNullGraphType<ServiceType>>(
                nameof(ServicesDetail.Service),
                resolve: context => context.Source.Service,
                description: "Thuộc dịch vụ nào");
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
        }
    }
}
