using GraphQL.Types;
using uit.ooad.Models;

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

            Field<BookingType>(nameof(ServicesDetail.Booking), resolve: context => context.Source.Booking,
                               description: "Thuộc thông tin thuê phòng nào");
            Field<ServiceType>(nameof(ServicesDetail.Service), resolve: context => context.Source.Service,
                               description: "Thuộc dịch vụ nào");
        }
    }
}
