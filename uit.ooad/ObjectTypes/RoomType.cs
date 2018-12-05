using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Name = "Room";
            Description = "Một phòng trong khách sạn";

            Field(x => x.Id).Description("Id của phòng");
            Field(x => x.Name).Description("Tên phòng");
            // Field(x => x.Floor).Description("Phòng thuộc tầng nào");
            // Field(x => x.RoomKind).Description("Loại phòng của phòng");

            Field<ListGraphType<BookingType>>("bookings", resolve: context => context.Source.Bookings.ToList(),
                                              description: "Danh sách thông tin thuê phòng");
        }
    }
}
