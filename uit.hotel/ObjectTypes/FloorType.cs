using System.Linq;
using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
{
    public class FloorType : ObjectGraphType<Floor>
    {
        public FloorType()
        {
            Name = nameof(Floor);
            Description = "Một tầng trong khách sạn";

            Field(x => x.Id).Description("Id của tầng");
            Field(x => x.Name).Description("Tên tầng");
            Field(x => x.IsActive).Description("Trạng thái hoạt động");
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<RoomType>>>>(
                nameof(Floor.Rooms),
                "Danh sách các phòng có trong tầng",
                resolve: context => context.Source.Rooms.ToList());
        }
    }

    public class FloorIdInput : InputType<Floor>
    {
        public FloorIdInput()
        {
            Name = _Id;
            Description = "Input cho một thông tin tầng";

            Field(x => x.Id).Description("Id của tầng");
        }
    }

    public class FloorCreateInput : InputType<Floor>
    {
        public FloorCreateInput()
        {
            Name = _Creation;
            Field(x => x.Name).Description("Tên tầng");
        }
    }

    public class FloorUpdateInput : InputType<Floor>
    {
        public FloorUpdateInput()
        {
            Name = _Updation;
            Field(x => x.Id).Description("Id tầng cần cập nhật");
            Field(x => x.Name).Description("Tên tầng");
        }
    }
}
