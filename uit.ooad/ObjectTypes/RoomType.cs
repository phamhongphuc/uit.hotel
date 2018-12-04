using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Name = "Room";
            Description = "Một tầng trong khách sạn";

            Field(x => x.Id).Description("Id của phòng");
            Field(x => x.Name).Description("Tên phòng");
        }
    }
}
