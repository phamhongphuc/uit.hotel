using System;
using System.Linq;
using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;
using uit.hotel.Queries.Helper;

namespace uit.hotel.ObjectTypes
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

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<RoomType>>>>(
                nameof(RoomKind.Rooms),
                "Danh sách các phòng thuộc loại phòng này",
                resolve: context => context.Source.Rooms.ToList()
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PriceType>>>>(
                nameof(RoomKind.Prices),
                "Danh sách giá cố định của loại phòng",
                resolve: context => context.Source.Prices.ToList()
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PriceVolatilityType>>>>(
                nameof(RoomKind.PriceVolatilities),
                "Danh sách giá biến động của loại phòng",
                resolve: context => context.Source.PriceVolatilities.ToList()
            );
            Field<NonNullGraphType<PriceType>>(
                "Current" + nameof(Price),
                "Giá cơ bản đang áp dụng",
                resolve: context => context.Source.GetPrice(DateTimeOffset.Now)
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PriceVolatilityType>>>>(
                "CurrentPriceVolatilities",
                "Danh sách giá biến động đang áp dụng",
                resolve: context => context.Source.GetPriceVolatilities(DateTimeOffset.Now.AtHour(0), DateTimeOffset.Now.AtHour(0).AddDays(1))
            );
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
