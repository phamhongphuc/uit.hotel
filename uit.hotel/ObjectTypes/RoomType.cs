using System;
using System.Linq;
using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Name = nameof(Room);
            Description = "Một phòng trong khách sạn";

            Field(x => x.Id).Description("Id của phòng");
            Field(x => x.Name).Description("Tên phòng");
            Field(x => x.IsActive).Description("Trạng thái phòng");
            Field(x => x.IsClean).Description("Trạng thái dọn phòng");

            Field<NonNullGraphType<BooleanGraphType>>(
                "isEmpty",
                "Phòng trống",
                new QueryArguments
                {
                    new QueryArgument<NonNullGraphType<DateTimeOffsetGraphType>> { Name = "from" },
                    new QueryArgument<NonNullGraphType<DateTimeOffsetGraphType>> { Name = "to" }
                },
                context =>
                {
                    var from = context.GetArgument<DateTimeOffset>("from");
                    var to = context.GetArgument<DateTimeOffset>("to");
                    return context.Source.IsEmpty(from, to);
                }
            );

            Field<BookingType>(
                "currentBooking",
                "Đơn đặt phòng hiện tại",
                new QueryArguments
                {
                    new QueryArgument<NonNullGraphType<DateTimeOffsetGraphType>> { Name = "from" },
                    new QueryArgument<NonNullGraphType<DateTimeOffsetGraphType>> { Name = "to" }
                },
                context =>
                {
                    var from = context.GetArgument<DateTimeOffset>("from");
                    var to = context.GetArgument<DateTimeOffset>("to");
                    return context.Source.GetCurrentBooking(from, to);
                }
            );

            Field<NonNullGraphType<FloorType>>(
                nameof(Room.Floor),
                "Phòng thuộc tầng nào",
                resolve: context => context.Source.Floor
            );
            Field<NonNullGraphType<RoomKindType>>(
                nameof(Room.RoomKind),
                "Loại phòng của phòng",
                resolve: context => context.Source.RoomKind
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BookingType>>>>(
                nameof(Room.Bookings),
                "Danh sách thông tin thuê phòng",
                resolve: context => context.Source.Bookings.ToList()
            );
        }
    }

    public class RoomCreateInput : InputType<Room>
    {
        public RoomCreateInput()
        {
            Name = _Creation;

            Field(x => x.Name).Description("Tên phòng");

            Field<NonNullGraphType<FloorIdInput>>(
                nameof(Room.Floor),
                "Phòng thuộc tầng nào"
            );
            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(Room.RoomKind),
                "Loại phòng của phòng"
            );
        }
    }

    public class RoomUpdateInput : InputType<Room>
    {
        public RoomUpdateInput()
        {
            Name = _Updation;

            Field(x => x.Id).Description("Id phòng cần cập nhật");
            Field(x => x.Name).Description("Tên phòng");

            Field<NonNullGraphType<FloorIdInput>>(
                nameof(Room.Floor),
                "Phòng thuộc tầng nào"
            );
            Field<NonNullGraphType<RoomKindIdInput>>(
                nameof(Room.RoomKind),
                "Loại phòng của phòng"
            );
        }
    }

    public class RoomIdInput : InputType<Room>
    {
        public RoomIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một phòng";

            Field(x => x.Id).Description("Id của phòng");
        }
    }
}
