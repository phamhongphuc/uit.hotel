using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Mutation
{
    public class RoomKindMutation : RootQueryGraphType
    {

        public RoomKindMutation()
        {
            Field<RoomKindType>(
                GetCreation(nameof(RoomKind)),
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