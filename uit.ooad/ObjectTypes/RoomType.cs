using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
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

            Field<NonNullGraphType<FloorType>>(
                nameof(Room.Floor),
                resolve: context => context.Source.Floor,
                description: "Phòng thuộc tầng nào"
            );
            Field<NonNullGraphType<RoomKindType>>(
                nameof(Room.RoomKind),
                resolve: context => context.Source.RoomKind,
                description: "Loại phòng của phòng"
            );

            Field<ListGraphType<BookingType>>(
                nameof(Room.Bookings),
                resolve: context => context.Source.Bookings.ToList(),
                description: "Danh sách thông tin thuê phòng"
            );
        }
    }

    public class RoomCreateInput : InputType<Room>
    {
        public RoomCreateInput()
        {
            Name = _Creation;

            Field(x => x.Name).Description("Tên phòng");
            Field(x => x.IsActive).Description("Trạng thái phòng");

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

            Field<FloorIdInput>(
                nameof(Room.Floor),
                "Phòng thuộc tầng nào"
            );
            Field<RoomKindIdInput>(
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
