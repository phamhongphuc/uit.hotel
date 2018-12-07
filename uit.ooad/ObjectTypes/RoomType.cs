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

            Field<FloorType>(nameof(Room.Floor), resolve: context => context.Source.Floor,
                             description: "Phòng thuộc tầng nào");
            Field<RoomKindType>(nameof(Room.RoomKind), resolve: context => context.Source.RoomKind,
                                description: "Loại phòng của phòng");

            Field<ListGraphType<BookingType>>(nameof(Room.Bookings),
                                              resolve: context => context.Source.Bookings.ToList(),
                                              description: "Danh sách thông tin thuê phòng");
        }
    }

    public class RoomCreateInput : InputType<Room>
    {
        public RoomCreateInput()
        {
            Name = _Creation;

            Field(x => x.Id).Description("Id của phòng");
            Field(x => x.Name).Description("Tên phòng");

            Field<FloorIdInput>(
                "Floor",
                "Phòng thuộc tầng nào"
            );
            Field<RoomKindIdInput>(
                "RoomKind",
                "Loại phòng của phòng"
            );
        }
    }
}
