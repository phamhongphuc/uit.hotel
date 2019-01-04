using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

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
            Field(x => x.Status).Description("Trạng thái dọn phòng");

            Field<EmployeeType>(
                nameof(HouseKeeping.Employee),
                "Nhân viên thực hiện dọn dẹp",
                resolve: context => context.Source.Employee);

            Field<NonNullGraphType<BookingType>>(
                nameof(HouseKeeping.Booking),
                "Thông tin chi tiết đặt trước của phòng cần chuẩn bị",
                resolve: context => context.Source.Booking);
        }
    }

    public class HouseKeepingCreateInput : InputType<HouseKeeping>
    {
        public HouseKeepingCreateInput()
        {
            Name = _Creation;

            Field<NonNullGraphType<BookingIdInput>>(
                nameof(HouseKeeping.Booking),
                "Thông tin đơn đặt phòng cần dọn dẹp"
            );
        }
    }

    public class HouseKeepingIdInput : InputType<HouseKeeping>
    {
        public HouseKeepingIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin  một công việc dọn dẹp";

            Field(x => x.Id).Description("Id của một công việc dọn dẹp");
        }
    }
}
