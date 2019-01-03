using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class RoomKindType : ObjectGraphType<RoomKind>
    {
        public RoomKindType()
        {
            Name = nameof(RoomKind);
            Description = "Một loại phòng hiện có trong khách sạn";

            Field(x => x.Id).Description("Id của loại phòng");
            Field(x => x.Name).Description("Tên loại phòng");
            Field(x => x.NumberOfBeds).Description("Số giường");
            Field(x => x.AmountOfPeople).Description("Số người trong một phòng");
            Field(x => x.IsActive).Description("Trạng thái phòng");

            Field<ListGraphType<RoomType>>(
                nameof(RoomKind.Rooms),
                resolve: context => context.Source.Rooms.ToList(),
                description: "Danh sách các phòng thuộc loại phòng này");

            Field<ListGraphType<RateType>>(
                nameof(RoomKind.Rates),
                resolve: context => context.Source.Rates.ToList(),
                description: "Danh sách giá cố định của loại phòng");

            Field<ListGraphType<VolatilityRateType>>(
                nameof(RoomKind.VolatilityRates),
                resolve: context => context.Source.VolatilityRates.ToList(),
                description: "Danh sách giá biến động của loại phòng");
        }
    }

    public class RoomKindIdInput : InputType<RoomKind>
    {
        public RoomKindIdInput()
        {
            Name = _Id;
            Description = "Input cho một thông tin một loại phòng";

            Field(x => x.Id).Description("Id của một loại phòng");
        }
    }

    public class RoomKindCreateInput : InputType<RoomKind>
    {
        public RoomKindCreateInput()
        {
            Name = _Creation;
            Description = "Input cho việc tạo một loại phòng";

            Field(x => x.Name).Description("Tên loại phòng");
            Field(x => x.NumberOfBeds).Description("Số giường");
            Field(x => x.AmountOfPeople).Description("Số người trong một phòng");
        }
    }

    public class RoomKindUpdateInput : InputType<RoomKind>
    {
        public RoomKindUpdateInput()
        {
            Name = _Updation;
            Description = "Input cho việc chỉnh sửa một loại phòng";

            Field(x => x.Id).Description("Id loại phòng");
            Field(x => x.Name).Description("Tên loại phòng");
            Field(x => x.NumberOfBeds).Description("Số giường");
            Field(x => x.AmountOfPeople).Description("Số người trong một phòng");
        }
    }
}
