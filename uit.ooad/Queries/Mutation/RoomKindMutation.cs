using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class RoomKindMutation : QueryType<RoomKind>
    {
        public RoomKindMutation()
        {
            Field<RoomKindType>(
                _Creation,
                "Tạo và trả về một loại phòng",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<IntGraphType> { Name = "numberOfBeds" },
                    new QueryArgument<IntGraphType> { Name = "amountOfPeople" },
                    new QueryArgument<IntGraphType> { Name = "priceByDate" }
                ),
                context => RoomKindBusiness.Add(new RoomKind
                {
                    Id = context.GetArgument<int>("id"),
                    Name = context.GetArgument<string>("name"),
                    NumberOfBeds = context.GetArgument<int>("numberOfBeds"),
                    AmountOfPeople = context.GetArgument<int>("amountOfPeople"),
                    PriceByDate = context.GetArgument<int>("priceByDate")
                })
            );
        }
    }
}
