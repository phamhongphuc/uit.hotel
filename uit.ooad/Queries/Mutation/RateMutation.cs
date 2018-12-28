using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class RateMutation : QueryType<Rate>
    {
        public RateMutation()
        {
            Field<NonNullGraphType<RateType>>(
                _Creation,
                "Tạo và trả về một loại giá cơ bản mới",
                _InputArgument<RateCreateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionCreateOrUpdateRate,
                    context => RateBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
