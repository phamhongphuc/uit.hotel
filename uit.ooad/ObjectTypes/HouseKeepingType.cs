using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class HouseKeepingType : ObjectGraphType<HouseKeeping>
    {
        public HouseKeepingType()
        {
            Name = nameof(HouseKeeping);
            Description = "Một hình thức dọn dẹp của một nhân viên buồng phòng tại một phòng trong khách sạn";

            Field(x => x.Id).Description("Id của việc dọn dẹp");
            Field(x => x.Type).Description("Hình thức dọn dẹp phòng");
            
            Field<EmployeeType>(nameof(HouseKeeping.Employee), resolve: context => context.Source.Employee, description: "Nhân viên thực hiện dọn dẹp");
            Field<BookingType>(nameof(HouseKeeping.Booking), resolve: context => context.Source.Booking, description: "Thông tin chi tiết đặt trước của phòng cần chuẩn bị");
        }
    }
}
