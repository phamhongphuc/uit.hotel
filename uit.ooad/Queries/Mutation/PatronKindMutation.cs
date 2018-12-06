using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Queries.Mutation
{
    public class PatronKindMutation : RootQueryGraphType
    {
        public PatronKindMutation()
        {
            Field<PatronKindType>(
                GetCreation(nameof(PatronKind)),
                "Tạo và trả về một loại khách hàng mới",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "description" }
                ),
                context => PatronKindBusiness.Add(new PatronKind
                {
                    Id = context.GetArgument<int>("id"),
                    Name = context.GetArgument<string>("name"),
                    Description = context.GetArgument<string>("description"),
                })
            );
        }
    }
}
