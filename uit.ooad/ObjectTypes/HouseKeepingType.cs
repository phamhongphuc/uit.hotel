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

            Field<NonNullGraphType<EmployeeType>>(
                nameof(HouseKeeping.Employee),
                resolve: context => context.Source.Employee,
                description: "Nhân viên thực hiện dọn dẹp");
            Field<NonNullGraphType<BookingType>>(
                nameof(HouseKeeping.Booking),
                resolve: context => context.Source.Booking,
                description: "Thông tin chi tiết đặt trước của phòng cần chuẩn bị");
        }
    }

    public class HouseKeepingCreateInput : InputType<HouseKeeping>
    {
        public HouseKeepingCreateInput()
        {
            Name = _Creation;

            Field(x => x.Type).Description("Loại hình thức dọn dẹp");

            Field<NonNullGraphType<EmployeeIdInput>>(
                nameof(HouseKeeping.Employee),
                "Nhân viên thực hiện dọn dẹp"
            );

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
