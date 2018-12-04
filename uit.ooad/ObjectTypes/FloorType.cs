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
            // Field(x => x.Rooms).Description("Danh sách các phòng có trong tầng");
        }
    }
}
