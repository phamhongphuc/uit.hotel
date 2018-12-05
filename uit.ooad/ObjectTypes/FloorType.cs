using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class FloorType : ObjectGraphType<Floor>
    {
        public FloorType()
        {
            Name = "Floor";
            Description = "Một tầng trong khách sạn";

            Field(x => x.Id).Description("Id của tầng");
            Field(x => x.Name).Description("Tên tầng");
            Field<ListGraphType<RoomType>>(
                nameof(Floor.Rooms),
                resolve: context => context.Source.Rooms.ToList(),
                description: "Danh sách các phòng có trong tầng"
            );
        }
    }
}
